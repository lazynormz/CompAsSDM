using System.Collections.Generic;
using MovieRating.Core.Model;

namespace MovieRating.Domain.IRepositories
{
    public interface IReviewRepository
    {
        List<MovieReview> FindAll();
    }
}