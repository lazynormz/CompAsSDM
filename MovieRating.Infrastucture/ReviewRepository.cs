using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MovieRating.Core.Model;
using MovieRating.Domain.IRepositories;

namespace MovieRating.Infrastucture
{
    public class ReviewRepository : IReviewRepository
    {
        private const string _fileName = "./ratings.json";

        private static List<MovieReview> _list;

        public ReviewRepository()
        {
            _list = new List<MovieReview>();
            initData();
        }

        private void initData()
        {
            using (StreamReader r = new StreamReader(_fileName))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (line.EndsWith(","))
                        line = line.Substring(0, line.Length - 2);
                    if(line.Contains("[") || line.Contains("]"))
                        continue;
                    _list.Add(JsonSerializer.Deserialize<MovieReview>(line));
                }
            }
        }

        public List<MovieReview> FindAll()
        {
            if (_list.Count == 0)
                initData();
            return _list;
        }
    }
}