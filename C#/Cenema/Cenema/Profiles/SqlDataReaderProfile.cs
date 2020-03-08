using AutoMapper;
using Cenema.Models.Domain;
using Cenema.Models.Reports;
using Cenema.Models.Tickets;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Cenema.Profiles
{
    public class SqlDataReaderProfile : Profile
    {
        public SqlDataReaderProfile()
        {
            CreateMap<SqlDataReader, Movie>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src["Id"]))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src["Title"]))
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src["Description"]))
                .ForMember(dst => dst.MinAge, opt => opt.MapFrom(src => src["MinAge"]))
                .ForMember(dst => dst.Duration, opt => opt.MapFrom(src => src["Duration"]))
                .ForMember(dst => dst.Rating, opt => opt.MapFrom(src => src["Rating"]))
                .ForMember(dst => dst.ImgUrl, opt => opt.MapFrom(src => src["ImgUrl"]))
                .ForMember(dst => dst.Director, opt => opt.MapFrom(src => src["Director"]))
                .ForMember(dst => dst.ReleaseDate, opt => opt.MapFrom(src => src["ReleaseDate"]))
                .ForMember(dst => dst.Genres, opt => opt.Ignore())
                .AfterMap((src, dst) =>
                {
                    var genres = src["Genres"] as string;
                    if (!string.IsNullOrWhiteSpace(genres))
                    {
                        var parsedGenres = genres.Split(',').Select(x => (Genres)Enum.Parse(typeof(Genres), x));
                        dst.Genres = parsedGenres.ToArray();
                    }
                })
                .ForAllOtherMembers(x => x.Ignore())
                ;
            CreateMap<SqlDataReader, Hall>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src["Id"]))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src["Name"]))
                .ForMember(dst => dst.Places, opt => opt.MapFrom(src => src["Places"]))
                .ForAllOtherMembers(x => x.Ignore())
                ;
            CreateMap<SqlDataReader, TimeSlot>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src["Id"]))
                .ForMember(dst => dst.StartTime, opt => opt.MapFrom(src => src["StartTime"]))
                .ForMember(dst => dst.Cost, opt => opt.MapFrom(src => src["Cost"]))
                .ForMember(dst => dst.MovieId, opt => opt.MapFrom(src => src["MovieId"]))
                .ForMember(dst => dst.HallId, opt => opt.MapFrom(src => src["HallId"]))
                .ForMember(dst => dst.Format, opt => opt.MapFrom(src => src["Format"]))
                .ForMember(dst => dst.RequestedSeats, opt => opt.Ignore())
                .ForAllOtherMembers(x => x.Ignore())
                ;
            CreateMap<SqlDataReader, TimeSlotSeatRequest>()
                .ForMember(dst => dst.Row, opt => opt.MapFrom(src => src["Row"]))
                .ForMember(dst => dst.Seat, opt => opt.MapFrom(src => src["Seat"]))
                .ForMember(dst => dst.Status, opt => opt.Ignore())
                .AfterMap((src, dst) =>
                {
                    var status = src["Status"] as string;
                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        dst.Status = (RequestStatus)Enum.Parse(typeof(RequestStatus), status);
                    }
                })
                .ForAllOtherMembers(x => x.Ignore());
                ;
            CreateMap<SqlDataReader, PotentialRealProfitReportRow>()
                .ForMember(x => x.Name, x => x.MapFrom(z => z["Title"]))
                .ForMember(x => x.GuaranteedProfit, x => x.MapFrom(z => z["GuaranteedProfit"]))
                .ForMember(x => x.PotentialProfit, x => x.MapFrom(z => z["TPotentialProfititle"]))
                ;
        }
    }
}