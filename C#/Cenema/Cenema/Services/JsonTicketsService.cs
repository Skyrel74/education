using Cenema.Interfaces;
using Cenema.Models;
using Cenema.Models.Domain;
using Cenema.Models.Domain.Tickets;
using Cenema.Models.Tickets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenema.Services
{
    public class JsonTicketsService : ITicketsService
    {
        private const string PathToJson = "/Files/Data.json";
        private HttpContext Context { get; set; }

        public JsonTicketsService()
        {
            Context = HttpContext.Current;
        }

        public Movie GetMovieById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie[] GetAllMovies()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Movies;
        }

        public Hall GetHallById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.Halls.FirstOrDefault(x => x.Id == id);
        }

        public Hall[] GetAllHalls()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Halls;
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots.FirstOrDefault(x => x.Id == id);
        }

        public TimeSlot[] GetAllTimeSlots()
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots;
        }

        public bool UpdateMovie(Movie updatedMovie)
        {
            var fullModel = GetDataFromFile();
            var movieToUpdate = fullModel.Movies.FirstOrDefault(x => x.Id == updatedMovie.Id);
            if (movieToUpdate == null)
                return false;
            movieToUpdate.Title = updatedMovie.Title;
            movieToUpdate.MinAge = updatedMovie.MinAge;
            movieToUpdate.Director = updatedMovie.Director;
            movieToUpdate.Duration = updatedMovie.Duration;
            movieToUpdate.Description = updatedMovie.Description;
            movieToUpdate.ImgUrl = updatedMovie.ImgUrl;
            movieToUpdate.Rating = updatedMovie.Rating;
            movieToUpdate.ReleaseDate = updatedMovie.ReleaseDate;
            if (updatedMovie.Genres != null)
                movieToUpdate.Genres = updatedMovie.Genres;
            SaveToFile(fullModel);
            return true;
        }

        private void SaveToFile(FileModel model)
        {
            var jsonFilePath = Context.Server.MapPath(PathToJson);
            var serializedModel = JsonConvert.SerializeObject(model);
            System.IO.File.WriteAllText(jsonFilePath, serializedModel);
        }

        private FileModel GetDataFromFile()
        {
            var jsonFilePath = Context.Server.MapPath(PathToJson);
            if (!System.IO.File.Exists(jsonFilePath))
                return null;
            var json = System.IO.File.ReadAllText(jsonFilePath);
            var fileModel = JsonConvert.DeserializeObject<FileModel>(json);
            return fileModel;
        }

        public bool UpdateHall(Hall updatedHall)
        {
            var fullModel = GetDataFromFile();
            var hallToUpdate = fullModel.Halls.FirstOrDefault(x => x.Id == updatedHall.Id);
            if (hallToUpdate == null)
                return false;
            hallToUpdate.Name = updatedHall.Name;
            hallToUpdate.Places = updatedHall.Places;
            SaveToFile(fullModel);
            return true;
        }

        public bool UpdateTimeSlot(TimeSlot updatedTimeSlot)
        {
            var fullModel = GetDataFromFile();
            var timeSlotToUpdate = fullModel.TimeSlots.FirstOrDefault
                (x => x.Id == updatedTimeSlot.Id);
            if (timeSlotToUpdate == null)
                return false;
            timeSlotToUpdate.StartTime = updatedTimeSlot.StartTime;
            timeSlotToUpdate.Cost = updatedTimeSlot.Cost;
            timeSlotToUpdate.MovieId = updatedTimeSlot.MovieId;
            timeSlotToUpdate.HallId = updatedTimeSlot.HallId;
            timeSlotToUpdate.Format = updatedTimeSlot.Format;
            SaveToFile(fullModel);
            return true;
        }

        public TimeSlot[] GetTimeSlotsByMovieId(int movieId)
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots.Where(x => x.MovieId == movieId).ToArray();
        }

        public bool CreateMovie(Movie newMovie)
        {
            var fullModel = GetDataFromFile();
            try
            {
                var newMovieId = fullModel.Movies.Max(m => m.Id) + 1;
                newMovie.Id = newMovieId;
                var existingMoviesList = fullModel.Movies.ToList();
                existingMoviesList.Add(newMovie);
                fullModel.Movies = existingMoviesList.ToArray();
                SaveToFile(fullModel);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool CreateHall(Hall newHall)
        {
            var fullModel = GetDataFromFile();
            try
            {
                var newHallId = fullModel.Halls.Max(m => m.Id) + 1;
                newHall.Id = newHallId;
                var existingHallsList = fullModel.Halls.ToList();
                existingHallsList.Add(newHall);
                fullModel.Halls = existingHallsList.ToArray();
                SaveToFile(fullModel);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool CreateTimeSlot(TimeSlot newTimeSlot)
        {
            var fullModel = GetDataFromFile();
            try
            {
                var newTimeSlotId = fullModel.TimeSlots.Max(m => m.Id) + 1;
                newTimeSlot.Id = newTimeSlotId;
                var existingTimeSlotsList = fullModel.TimeSlots.ToList();
                existingTimeSlotsList.Add(newTimeSlot);
                fullModel.TimeSlots = existingTimeSlotsList.ToArray();
                SaveToFile(fullModel);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool RemoveMovie(int movieId)
        {
            var fullModel = GetDataFromFile();
            var existingMoviesList = fullModel.Movies.ToList();
            var movieToDelete = existingMoviesList.FirstOrDefault(x => x.Id == movieId);
            var timeSlotsWithoutHall = fullModel.TimeSlots.Where(x => x.MovieId != movieId).ToList();
            if (movieToDelete == null)
                return false;
            fullModel.TimeSlots = timeSlotsWithoutHall.ToArray();
            existingMoviesList.Remove(movieToDelete);
            fullModel.Movies = existingMoviesList.ToArray();
            SaveToFile(fullModel);
            return true;
        }

        public bool RemoveHall(int hallId)
        {
            var fullModel = GetDataFromFile();
            var existingHallsList = fullModel.Halls.ToList();
            var hallToDelete = existingHallsList.FirstOrDefault(x => x.Id == hallId);
            var timeSlotsWithoutHall = fullModel.TimeSlots.Where(x => x.HallId != hallId).ToList();
            if (hallToDelete == null)
                return false;
            fullModel.TimeSlots = timeSlotsWithoutHall.ToArray();
            existingHallsList.Remove(hallToDelete);
            fullModel.Halls = existingHallsList.ToArray();
            SaveToFile(fullModel);
            return true;
        }

        public bool RemoveTimeSlot(int timeSlotId)
        {
            var fullModel = GetDataFromFile();
            var existingTimeSlotsList = fullModel.TimeSlots.ToList();
            var timeSlotToDelete = existingTimeSlotsList.FirstOrDefault(x => x.Id == timeSlotId);
            if (timeSlotToDelete == null)
                return false;
            existingTimeSlotsList.Remove(timeSlotToDelete);
            fullModel.TimeSlots = existingTimeSlotsList.ToArray();
            SaveToFile(fullModel);
            return true;
        }

        public MovieListItem[] GetFullMoviesInfo()
        {
            var allMovies = GetAllMovies();
            var resultModel = new List<MovieListItem>();
            foreach(var movie in allMovies)
            {
                resultModel.Add(new MovieListItem
                {
                    Movie = movie,
                    AvailableTimeSlots = GetTimeSlotTagsByMovieId(movie.Id)
                });
            }
            return resultModel.ToArray();
        }

        public TimeSlotTag[] GetTimeSlotTagsByMovieId(int movieId)
        {
            var timeSlots = GetTimeSlotsByMovieId(movieId);
            var resultModel = new List<TimeSlotTag>();
            foreach(var timeSlot in timeSlots)
            {
                resultModel.Add(new TimeSlotTag
                {
                    TimeSlotId = timeSlot.Id,
                    StartTime = timeSlot.StartTime,
                    Cost = timeSlot.Cost
                });
            }
            return resultModel.ToArray();
        }

        public bool AddRequestedSeatsToTimeSlot(SeatsProcessRequest request)
        {
            if (!(request?.SeatsRequest?.AddedSeats?.Any() ?? false)) return false;
            var fullModel = GetDataFromFile();
            var timeSlotsForUpdate = fullModel.TimeSlots.FirstOrDefault(x => x.Id == request.TimeSlotId);
            if (timeSlotsForUpdate == null) return false;
            var requestToProcess = new List<TimeSlotSeatRequest>();
            if (timeSlotsForUpdate.RequestedSeats != null && timeSlotsForUpdate.RequestedSeats.Any())
            {
                requestToProcess = timeSlotsForUpdate.RequestedSeats.ToList();
            }

            foreach (var addedSeat in request.SeatsRequest.AddedSeats)
            {
                requestToProcess.Add(new TimeSlotSeatRequest() {
                    Row = addedSeat.Row,
                    Seat = addedSeat.Seat,
                    Status = request.SelectedStatus
                });
            }

            timeSlotsForUpdate.RequestedSeats = requestToProcess.ToArray();
            SaveToFile(fullModel);
            return true;
        }
    }
}