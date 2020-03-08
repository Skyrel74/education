using Cenema.DataBaseLayer;
using Cenema.Interfaces;
using Cenema.Models.Domain;
using Cenema.Models.Domain.Tickets;
using Cenema.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;

namespace Cenema.Services
{
    public class EntityTicketsService : ITicketsService
    {
        public bool AddRequestedSeatsToTimeSlot(SeatsProcessRequest request)
        {
            throw new NotImplementedException();
        }

        public bool CreateHall(Hall newHall)
        {
            throw new NotImplementedException();
        }

        public bool CreateMovie(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public bool CreateTimeSlot(TimeSlot newTimeSlot)
        {
            throw new NotImplementedException();
        }

        public Hall[] GetAllHalls()
        {
            using (var context = new CinemaContext())
            {
                return context.Halls.ToArray();
            }
        }

        public Movie[] GetAllMovies()
        {
            using (var context = new CinemaContext())
            {
                return context.Movies.ToArray();
            }
        }

        private MovieListItem[] GetMoviesInfo(string term = "")
        {
            var model = new List<MovieListItem>();
            using(var context = new CinemaContext())
            {
                IQueryable<Movie> movieQuery = context.Movies;
                if (!string.IsNullOrEmpty(term))
                {
                    movieQuery = context.Movies.Where(x => x.Title.Contains(term));
                }
                foreach(var movie in movieQuery.ToArray())
                {
                    var movieListItem = new MovieListItem()
                    {
                        Movie = movie,
                        AvailableTimeSlots = context.TimeSlots.Where(timeslot => timeslot.MovieId == movie.Id)
                        .Select(timeslot => new TimeSlotTag
                        {
                            Cost = timeslot.Cost,
                            StartTime = timeslot.StartTime,
                            TimeSlotId = timeslot.Id
                        }).ToArray()
                    };
                    model.Add(movieListItem);
                }
            }
            return model.ToArray();
        }

        public TimeSlot[] GetAllTimeSlots()
        {
            using (var context = new CinemaContext())
            {
                return context.TimeSlots
                    .Include(x => x.Movie).Where(x => x.Movie != null)
                    .Include(x => x.Hall).Where(x => x.Hall != null)
                    .ToArray();
            }
        }

        public MovieListItem[] GetFullMoviesInfo()
        {
            var model = new List<MovieListItem>();
            using (var context = new CinemaContext())
            {
                foreach (var movie in context.Movies.ToArray())
                {
                    var movieListItem = new MovieListItem
                    {
                        Movie = movie,
                        AvailableTimeSlots = context.TimeSlots
                            .Where(timeslot => timeslot.MovieId == movie.Id)
                            .Select(timeslot => new TimeSlotTag
                            {
                                Cost = timeslot.Cost,
                                StartTime = timeslot.StartTime,
                                TimeSlotId = timeslot.Id
                            })
                            .ToArray()
                    };
                    model.Add(movieListItem);
                }
            }
            return model.ToArray();
        }

        public Hall GetHallById(int id)
        {
            using (var context = new CinemaContext())
            {
                return context.Halls.FirstOrDefault(x => x.Id == id);
            }
        }

        public Movie GetMovieById(int id)
        {
            using (var context = new CinemaContext())
            {
                return context.Movies.FirstOrDefault(x => x.Id == id);
            }
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            using (var context = new CinemaContext())
            {
                return context.TimeSlots.FirstOrDefault(x => x.Id == id);
            }
        }

        public TimeSlot[] GetTimeSlotsByMovieId(int movieId)
        {
            using (var context = new CinemaContext())
            {
                return context.TimeSlots.Where(x => x.MovieId == movieId).ToArray();
            }
        }

        public TimeSlotTag[] GetTimeSlotTagsByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveHall(int hallId)
        {
            using (var context = new CinemaContext())
            {
                var hall = context.Halls.FirstOrDefault(x => x.Id == hallId);
                context.Movies.FirstOrDefault
                    (x => x.Id == context.TimeSlots.FirstOrDefault(y => y.HallId == hall.Id).MovieId)
                    .IsDeleted = true;
                context.SaveChanges();
            }
            return true;
        }

        public bool RemoveMovie(int movieId)
        {
            using (var context = new CinemaContext())
            {
                var movie = context.Movies.FirstOrDefault(x => x.Id == movieId);
                movie.IsDeleted = true;
                context.SaveChanges();
            }
            return true;
        }

        public bool RemoveTimeSlot(int timeSlotId)
        {
            using (var context = new CinemaContext())
            {
                var timeslot = context.TimeSlots.FirstOrDefault(x => x.Id == timeSlotId);
                context.Movies.FirstOrDefault(x => x.Id == timeslot.MovieId).IsDeleted = true;
                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateHall(Hall updatedHall)
        {
            using (var context = new CinemaContext())
            {
                context.Halls.AddOrUpdate(updatedHall);
                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateMovie(Movie updatedMovie)
        {
            using (var context = new CinemaContext())
            {
                context.Movies.AddOrUpdate(updatedMovie);
                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateTimeSlot(TimeSlot updatedTimeSlot)
        {
            using (var context = new CinemaContext())
            {
                context.TimeSlots.AddOrUpdate(updatedTimeSlot);
                context.SaveChanges();
            }
            return true;
        }

    }
}