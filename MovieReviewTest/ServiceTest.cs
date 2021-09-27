using MovieRating.Core.IService;
using MovieRating.Domain.Service;
using Xunit;
namespace MovieReviewTest
{
    public class ServiceTest
    {
        private IReviewService rs;
        
        public ServiceTest()
        {
            rs = new ReviewService();
        }

        [Fact]
        public void GetNumberOfReviews()
        {
            
            //rs.GetNumberOfReviewsFromReviewer()
        }
    }
}