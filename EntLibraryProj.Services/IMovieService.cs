using EntLibraryProj.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntLibraryProj.Services
{
    public interface IMovieService
    {
        public IEnumerable<Movie> GetMovies();
        public Movie? GetMovie(int id);
        public void DeleteMovie(Movie movie);
        public void AddMovie(Movie movie);
        public void UpdateMovie(Movie movie);
    }
}
