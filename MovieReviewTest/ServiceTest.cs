using MovieRating.Core.IService;
using MovieRating.Domain.Service;
using MovieRating.Infrastucture;
using Xunit;
namespace MovieReviewTest
{
    public class ServiceTest
    {
        private ReviewRepository rr;
        private IReviewService rs;

        public ServiceTest()
        {
            rr = new ReviewRepository();
            rs = new ReviewService(rr);
        }

        [Fact]
        public void TestAmountOfReviewsFromReviewer()
        {
            int expectedResult = 547;
            int wantedReviewer = 1;
            int amount = rs.GetNumberOfReviewsFromReviewer(wantedReviewer);
            Assert.Equal(expectedResult, amount);
        }

        [Fact]
        public void TestAverageRatingFromReviewer()
        {
            int wantedViewer = 6;
            double expectedResult = 5;
            double result = rs.GetAverageRateFromReviewer(wantedViewer);
            Assert.Equal(expectedResult, result);
        }
    }
}