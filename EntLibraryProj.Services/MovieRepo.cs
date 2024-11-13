using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public class MovieRepo : IMovieService
    {

        private readonly LibraryDbContext _context;

        public MovieRepo(LibraryDbContext context)
        {
            _context = context;
        }

        public void AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            Movie? M = _context.Movies.Find(movie.Id);
            if (M == null) { return; }
            _context.Movies.Remove(M);
            _context.SaveChanges();
        }

        public Movie? GetMovie(int id)
        {
            Movie? M = _context.Movies.Find(id);
            return M;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        public void UpdateMovie(Movie movie)
        {
           Movie? M = _context.Movies.Find(movie.Id);
            if (M == null) { return; }
            M.Title = movie.Title;
            M.Director = movie.Director;
            M.Length = movie.Length;
            M.Description = movie.Description;
            M.Created = movie.Created;
            _context.SaveChanges();
        }
    }
}
