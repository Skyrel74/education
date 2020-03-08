using Cenema.Models.Domain;
using Cenema.Models.Domain.Tickets;
using Cenema.Models.Tickets;

namespace Cenema.Interfaces
{
    public interface ITicketsService
    {
        Movie GetMovieById(int id);
        Movie[] GetAllMovies();
        MovieListItem[] GetFullMoviesInfo();
        bool UpdateMovie(Movie updatedMovie);

        Hall GetHallById(int id);
        Hall[] GetAllHalls();
        bool UpdateHall(Hall updatedHall);

        TimeSlot GetTimeSlotById(int id);
        TimeSlot[] GetAllTimeSlots();
        bool UpdateTimeSlot(TimeSlot updatedTimeSlot);
        TimeSlotTag[] GetTimeSlotTagsByMovieId(int movieId);

        TimeSlot[] GetTimeSlotsByMovieId(int movieId);

        bool CreateMovie(Movie newMovie);

        bool CreateHall(Hall newHall);

        bool CreateTimeSlot(TimeSlot newTimeSlot);

        bool RemoveMovie(int movieId);

        bool RemoveHall(int hallId);
        bool RemoveTimeSlot(int timeSlotId);
        bool AddRequestedSeatsToTimeSlot(SeatsProcessRequest request);
    }
}
