using AutoMapper;
using DeltaX.Entities;
using Deltax.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Deltax.Services;


public interface IMovieServices
{
    ResponseStatus<IIncludableQueryable<TblMovieDetail, TblActor>> GetAllMoviesAsync();
    ResponseStatus<IQueryable<TblMovieDetail>> GetMovieById(int movieId);
    ResponseStatus<MovieDTO> UpdateMovie(MovieDTO movie);
    ResponseStatus<MovieDTO> CreateMovie(MovieDTO movie);
}
public class MovieServices : IMovieServices
{
    private readonly DeltaXDBContext _context;
    private readonly IMapper _mapper;

    public MovieServices(DeltaXDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ResponseStatus<IIncludableQueryable<TblMovieDetail, TblActor>> GetAllMoviesAsync()
    {
        try
        {
            var data = _context.TblMovieDetails.Include(movie => movie.Movie).Include(actor => actor.Actor);

            return new ResponseStatus<IIncludableQueryable<TblMovieDetail, TblActor>>
            {
                Status = BussinessStatus.Ok,
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IIncludableQueryable<TblMovieDetail, TblActor>>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the Movie data"
            };
        }
    }

    public ResponseStatus<IQueryable<TblMovieDetail>> GetMovieById(int movieId)
    {
        try
        {
            var data = _context.TblMovieDetails.Include(movie => movie.Movie).Include(actor => actor.Actor).Where(x => x.MovieId == movieId);
            return new ResponseStatus<IQueryable<TblMovieDetail>>
            {
                Status = BussinessStatus.Ok,
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IQueryable<TblMovieDetail>>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the Movie data"
            };
        }
    }
    public ResponseStatus<MovieDTO> UpdateMovie(MovieDTO movie)
    {
        try
        {
            var data = _context.TblMovies.Where(x => x.MovieId == movie.MovieId);

            if (data.Count() > 0)
            {
                _context.TblMovies.Update(_mapper.Map<TblMovie>(movie));

                _context.SaveChanges();

                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Updated,
                    ResponseMessage = "Updated Successfully"
                };
            }
            else
            {
                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.NotFound,
                    ResponseMessage = "Cannot find the movie to update"
                };
            }



        }
        catch (Exception ex)
        {
            return new ResponseStatus<MovieDTO>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not update the Movie data"
            };
        }
    }

    public ResponseStatus<MovieDTO> CreateMovie(MovieDTO movie)
    {
        try
        {
            var data = _context.TblMovies.Where(x => x.MovieId == movie.MovieId);

            if (data.Count() > 0)
            {
                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Error,
                    ResponseMessage = "Movie Already Exist"
                };

            }
            else
            {
                _context.TblMovies.Add(_mapper.Map<TblMovie>(movie));
                _context.SaveChanges();

                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Created,
                    ResponseMessage = "Movie added Successfully"
                };
            }



        }
        catch (Exception ex)
        {
            return new ResponseStatus<MovieDTO>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not update the Movie data"
            };
        }
    }

}