using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
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
            rr = new ReviewRepository("MOCK.json");
            rs = new ReviewService(rr);
        }

        [Fact]
        public void TestAmountOfReviewsFromReviewer()
        {
            int expectedResult = 5;
            int wantedReviewer = 1;
            int amount = rs.GetNumberOfReviewsFromReviewer(wantedReviewer);
            Assert.Equal(expectedResult, amount);
        }

        [Fact]
        public void TestAverageRatingFromReviewer()
        {
            int wantedViewer = 4;
            double expectedResult = 2.4d;
            double result = rs.GetAverageRateFromReviewer(wantedViewer);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Test_GetNumberOfRatesByReviewer()
        {
            int wantedReviewer = 4;
            int wantedRate = 1;
            int expectedResult = 2;
            int result = rs.GetNumberOfRatesByReviewer(wantedReviewer, wantedRate);
            Assert.Equal(expectedResult, result);
        }

        [Fact]

        public void TestGetNumberOfReviews()
        {
            int wantedMovie = 4;
            int expectedResult = 2;
            int result = rs.GetNumberOfReviews(wantedMovie);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestGetAverageRateOfMovie()
        {
            double expectedResult = 3.5d;
            int wantedMovie = 4;
            double result = rs.GetAverageRateOfMovie(wantedMovie);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestGetNumberOfRates()
        {
            int movie = 2, rate = 2;
            int expectedResult = 2;
            int result = rs.GetNumberOfRates(movie, rate);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestGetTopRatedMovies()
        {
            int requestedAmount = 1;
            List<int> expectedResult = new List<int>();
            expectedResult.Add(7);
            List<int> result = rs.GetTopRatedMovies(requestedAmount);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestGetMostProductiveReviewers()
        {
            List<int> expectedResult = new List<int>();
            expectedResult.Add(1);
            expectedResult.Add(2);
            expectedResult.Add(3);
            expectedResult.Add(4);
            List<int> result = rs.GetMostProductiveReviewers(); 
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestGetMoviesWithHighestNumberOfTopRates()
        {
            
        }
    }
}