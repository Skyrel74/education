using AutoMapper;
using Cenema.Interfaces;
using Cenema.Models.Domain;
using Cenema.Models.Domain.Tickets;
using Cenema.Models.Tickets;
using Cenema.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Cenema.Services
{
    public class SqlTicketsService : ITicketsService
    {
        private readonly SqlDatabaseUtil _sqlDatabaseUtil;

        public SqlTicketsService(IMapper mapper)
        {
            _sqlDatabaseUtil = new SqlDatabaseUtil(mapper);
        }
        public bool AddRequestedSeatsToTimeSlot(SeatsProcessRequest request)
        {
            if (!(request?.SeatsRequest?.AddedSeats?.Any() ?? false)) return false;

            foreach (var seatsRequestAddedSeat in request.SeatsRequest.AddedSeats)
            {
                _sqlDatabaseUtil.Execute("insert into requestedseats (timeslotid, row, seat, status) " +
                                         "values (@timeslotid,@row, @seat, @status)",
                new SqlParameter("@timeslotid", request.TimeSlotId),
                new SqlParameter("@row", seatsRequestAddedSeat.Row),
                new SqlParameter("@seat", seatsRequestAddedSeat.Seat),
                new SqlParameter("@status", request.SelectedStatus.ToString()));
            }

            return true;
        }

        public bool CreateHall(Hall newHall)
        {
            return _sqlDatabaseUtil.Execute("insert into halls (name, places) values (@name, @places)",
                new SqlParameter("@name", newHall.Name),
                new SqlParameter("@places", newHall.Places)
                );
        }

        public bool CreateMovie(Movie newMovie)
        {
            return _sqlDatabaseUtil.Execute("insert into movies (title, description, duration, minage, director, imgurl, rating, releasedate, genres)" +
                "values (@title, @descriotion, @duration, @minage, @director, @imgurl, @rating, @releasedate, @genres)",
                ToParameter("@title", newMovie.Title),
                ToParameter("@descriotion", newMovie.Description),
                ToParameter("@duration", newMovie.Duration),
                ToParameter("@minage", newMovie.MinAge),
                ToParameter("@director", newMovie.Director),
                ToParameter("@imgurl", newMovie.ImgUrl),
                ToParameter("@rating", newMovie.Rating),
                ToParameter("@releasedate", newMovie.ReleaseDate),
                ToParameter("@genres", String.Join(",", newMovie?.Genres ?? new Genres[0]))
                );
        }

        private SqlParameter ToParameter(string name, object value)
        {
            if (value == null) return new SqlParameter(name, DBNull.Value);
            return new SqlParameter(name, value);
        }

        public bool CreateTimeSlot(TimeSlot newTimeSlot)
        {
            return _sqlDatabaseUtil.Execute("insert into timeslots (starttime, cost, movieid, hallid) values (@starttime, @cost, @movieid, @hallid)",
                new SqlParameter("@starttime", newTimeSlot.StartTime),
                new SqlParameter("@cost", newTimeSlot.Cost),
                new SqlParameter("@movieid", newTimeSlot.MovieId),
                new SqlParameter("@hallid", newTimeSlot.HallId)
                );
        }

        public Hall[] GetAllHalls()
        {
            return _sqlDatabaseUtil.Select<Hall>("select * from halls").ToArray();
        }

        public Movie[] GetAllMovies()
        {
            return _sqlDatabaseUtil.Select<Movie>("select * from movies").ToArray();
        }

        public TimeSlot[] GetAllTimeSlots()
        {
            return _sqlDatabaseUtil.Select<TimeSlot>("select * from timeslots").ToArray();
        }

        public MovieListItem[] GetFullMoviesInfo()
        {
            var allMovies = GetAllMovies();
            var resultModel = new List<MovieListItem>();
            foreach (var movie in allMovies)
            {
                resultModel.Add(
                    new MovieListItem
                    {
                        Movie = movie,
                        AvailableTimeSlots = GetTimeSlotTagsByMovieId(movie.Id)
                    });
            }

            return resultModel.ToArray();
        }

        public Hall GetHallById(int id)
        {
            return _sqlDatabaseUtil.Select<Hall>("select * from halls where id = @id", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public Movie GetMovieById(int id)
        {
            return _sqlDatabaseUtil.Select<Movie>("select * from movies where id = @id", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            return _sqlDatabaseUtil.Select<TimeSlot>("select * from timeslots where id = @id", new SqlParameter("@id", id)).FirstOrDefault();
        }

        public TimeSlot[] GetTimeSlotsByMovieId(int movieId)
        {
            return _sqlDatabaseUtil.Select<TimeSlot>("select * from timeslots where movieid = @movieid", new SqlParameter("@movieid", movieId))
                .ToArray();
        }

        public TimeSlotTag[] GetTimeSlotTagsByMovieId(int movieId)
        {
            var timeslots = GetTimeSlotsByMovieId(movieId);
            var resultModel = new List<TimeSlotTag>();
            foreach (var timeslot in timeslots)
            {
                resultModel.Add(new TimeSlotTag
                {
                    TimeSlotId = timeslot.Id,
                    StartTime = timeslot.StartTime,
                    Cost = timeslot.Cost
                });
            }

            return resultModel.ToArray();
        }

        public bool RemoveHall(int id)
        {
            return _sqlDatabaseUtil.Execute("delete from halls where id = @id", new SqlParameter("id", id));
        }

        public bool RemoveMovie(int id)
        {
            return _sqlDatabaseUtil.Execute("delete from movies where id = @id", new SqlParameter("id", id));
        }

        public bool RemoveTimeSlot(int id)
        {
            return _sqlDatabaseUtil.Execute("delete from timeslots where id = @id", new SqlParameter("id", id));
        }

        public bool UpdateHall(Hall updatedHall)
        {
            return _sqlDatabaseUtil.Execute("update halls set name = @name, places = @places where id = @id",
                new SqlParameter("@id", updatedHall.Id),
                new SqlParameter("@name", updatedHall.Name),
                new SqlParameter("@places", updatedHall.Places)
                );
        }

        public bool UpdateMovie(Movie updatedMovie)
        {
            return _sqlDatabaseUtil.Execute("update movies set title = @title, description = @description, duration = @duration," +
                "minage = @minage, director = @director, imgurl = @imgurl, rating = @rating, releasedate = @releasedate, genres = @genres where id = @id",
                new SqlParameter("@id", updatedMovie.Id),
                new SqlParameter("@title", updatedMovie.Title),
                new SqlParameter("@description", updatedMovie.Description),
                new SqlParameter("@duration", updatedMovie.Duration),
                new SqlParameter("@minage", updatedMovie.MinAge),
                new SqlParameter("@director", updatedMovie.Director),
                new SqlParameter("@imgurl", updatedMovie.ImgUrl),
                new SqlParameter("@rating", updatedMovie.Rating),
                new SqlParameter("@releasedate", updatedMovie.ReleaseDate),
                new SqlParameter("@genres", String.Join(",", updatedMovie.Genres))
                );
        }

        public bool UpdateTimeSlot(TimeSlot updatedTimeSlot)
        {
            return _sqlDatabaseUtil.Execute("update timeslots set starttime = @starttime, cost = @cost," +
                "movieid = @movieid, hallid = @hallid where id = @id",
                new SqlParameter("@id", updatedTimeSlot.Id),
                new SqlParameter("@starttime", updatedTimeSlot.StartTime),
                new SqlParameter("@cost", updatedTimeSlot.Cost),
                new SqlParameter("@movieid", updatedTimeSlot.MovieId),
                new SqlParameter("@hallid", updatedTimeSlot.HallId)
                );
        }
    }
}