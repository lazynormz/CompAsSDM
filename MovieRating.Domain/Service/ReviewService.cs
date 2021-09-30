using System.Collections.Generic;
using System.Linq;
using MovieRating.Core.IService;
using MovieRating.Core.Model;
using MovieRating.Domain.IRepositories;

namespace MovieRating.Domain.Service
{
    public class ReviewService : IReviewService
    {
        private IReviewRepository rp;
        private List<MovieReview> _list = new List<MovieReview>();
        public ReviewService(IReviewRepository Irp)
        {
            rp = Irp;
            _list = rp.FindAll();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int i = 0;
            foreach (MovieReview mr in _list)
            {
                if (mr.Reviewer == reviewer)
                    i++;
            }

            return i;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            double total = 0;
            double ratings = 0;
            foreach (MovieReview mr in _list)
            {
                if (mr.Reviewer == reviewer)
                {
                    total += mr.Grade;
                    ratings++;
                }
            }

            if (ratings == 0)
                return -1;
            
            // ReSharper disable once PossibleLossOfFraction
            double returnValue = total / ratings;
            return returnValue;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            int totalrates = 0;
            foreach (MovieReview review in _list)
            {
                if (review.Reviewer == reviewer)
                {
                    if (review.Grade == rate)
                    {
                        totalrates++;
                    }
                }
            }
            return totalrates;
        }

        public int GetNumberOfReviews(int movie)
        {
            int totalMovieReviews = 0;
            foreach (MovieReview review in _list)
            {
                if (review.Movie == movie)
                {
                    totalMovieReviews++;
                }
            }
            return totalMovieReviews;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            double averageMovieRate = 0;
            int totalReviews = GetNumberOfReviews(movie);
            int sumOfRates = 0;
            foreach (MovieReview review in _list)
            {
                if (review.Movie == movie)
                {
                    sumOfRates += review.Grade;
                }
            }

            averageMovieRate = (double)sumOfRates/totalReviews;
            
            return averageMovieRate;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            int totalNumberofMovieRate = 0;
            foreach (MovieReview review in _list)
            {
                if (review.Movie == movie && review.Grade == rate)
                {
                    totalNumberofMovieRate++;
                }
            }
            return totalNumberofMovieRate;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            List<int> topRatedMovies = new List<int>();
            int highestAmountOfTopRatings = 0;
            foreach (MovieReview review in _list)
            {
                int amountOfTopRatings = GetNumberOfRates(review.Movie, 5);
                if (!topRatedMovies.Contains(review.Movie))
                {
                    if (amountOfTopRatings > highestAmountOfTopRatings)
                    {
                        topRatedMovies = new List<int>();
                        topRatedMovies.Add(review.Movie);
                        highestAmountOfTopRatings = amountOfTopRatings;
                    }
                    else if (amountOfTopRatings == highestAmountOfTopRatings)
                    {
                        topRatedMovies.Add(review.Movie);
                    }
                }
            }

            return topRatedMovies;
        }

        public List<int> GetMostProductiveReviewers()
        {
            List<int> mostProductiveReviewers = new List<int>();
            int highestAmountOfRatings = 0;
            foreach (MovieReview review in _list)
            {
                int amountOfTopRatings = GetNumberOfReviewsFromReviewer(review.Reviewer);
                if (amountOfTopRatings > highestAmountOfRatings && !mostProductiveReviewers.Contains(review.Reviewer))
                {
                    mostProductiveReviewers = new List<int>();
                    mostProductiveReviewers.Add(review.Reviewer);
                    highestAmountOfRatings = amountOfTopRatings;
                }
                else if (amountOfTopRatings == highestAmountOfRatings && !mostProductiveReviewers.Contains(review.Reviewer))
                {
                    mostProductiveReviewers.Add(review.Reviewer);
                }
            }

            return mostProductiveReviewers;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            List<int> movies = new List<int>();
            foreach(MovieReview review in _list)
            {
                if (!movies.Contains(review.Movie))
                {
                    movies.Add(review.Movie);
                }
            }
            
            //<Movie, amountOfTopReviews>
            Dictionary<int, int> movieTopReview = new Dictionary<int, int>();

            foreach (int movie in movies)
            {
                int numberOfTopRates = GetNumberOfRates(movie, 5);
                
                movieTopReview.Add(movie, numberOfTopRates);
            }

            movieTopReview = movieTopReview.OrderBy(m => m.Value).ToDictionary(m => m.Key, m => m.Value);
            List<int> topMovieList = new List<int>();
            for (int i = movieTopReview.Count - amount; i < movieTopReview.Count; i++)
            {
                topMovieList.Add(movieTopReview.ElementAt(i).Key);
            }
            
            return topMovieList;
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            List<MovieReview> reviewsByReviewer = new List<MovieReview>();
            foreach (MovieReview review in _list)
            {
                if (review.Reviewer == reviewer)
                {
                    reviewsByReviewer.Add(review);
                }
            }

            reviewsByReviewer = reviewsByReviewer.OrderByDescending((r => r.Date)).ToList();
            reviewsByReviewer = reviewsByReviewer.OrderByDescending(r => r.Grade).ToList();

            List<int> movieList = new List<int>();

            foreach (MovieReview review in reviewsByReviewer)
            {
                movieList.Add(review.Movie);
            }




            return movieList;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            List<MovieReview> reviewsOfMovie = new List<MovieReview>();
            foreach (MovieReview movieReview in _list)
            {
                
            }
            return null;
        }
    }
}