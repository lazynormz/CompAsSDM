using System.Collections.Generic;
using MovieRating.Core.IService;

namespace MovieRating.Domain.Service
{
    public class ReviewService : IReviewService
    {
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return -1;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            return -1;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return -1;
        }

        public int GetNumberOfReviews(int movie)
        {
            return -1;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            return -1;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            return -1;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return null;
        }

        public List<int> GetMostProductiveReviewers()
        {
            return null;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return null;
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            return null;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            return null;
        }
    }
}