using AutoMapper;
using DeltaX.Entities;
using Deltax.Models;

namespace Deltax.Helpers.AutoMap;

public class AutoMapperClass : Profile
{
    public AutoMapperClass()
    {
        CreateMap<TblActor, ActorDTO>().ReverseMap();
        CreateMap<TblMovie, MovieDTO>().ReverseMap();
        CreateMap<TblProducer, ProducerDTO>().ReverseMap();
        CreateMap<TblMovieDetail, MovieDetailDTO>().ReverseMap();
    }
}