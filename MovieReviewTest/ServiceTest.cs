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

        [Fact]
        public void Test_GetNumberOfRatesByReviewer()
        {
            int wantedReviewer = 1;
            int wantedRate = 3;
            int expectedResult = 136;
            int result = rs.GetNumberOfRatesByReviewer(wantedReviewer, wantedRate);
            Assert.Equal(expectedResult, result);
        }

        [Fact]

        public void TestGetNumberOfReviews()
        {
            int wantedMovie = 786312;
            int expectedResult = 2;
            int result = rs.GetNumberOfReviews(wantedMovie);
            Assert.Equal(expectedResult, result);
        }
    }
}