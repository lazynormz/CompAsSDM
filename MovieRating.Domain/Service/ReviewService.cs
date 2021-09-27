﻿using System.Collections.Generic;
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
            int total = 0;
            int ratings = 0;
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