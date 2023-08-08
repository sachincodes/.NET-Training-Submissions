using AjexTask.Models;

namespace AjexTask.Services
{
    public class ReviewService
    {
        public List<ReviewModel>Review(int skipItem,int takeItem)
        {
            var reviews = GetReview();
            return reviews
                .Skip(skipItem)
                .Take(takeItem)
                .ToList();
        }
        private List<ReviewModel> GetReview()
        {
            List<ReviewModel> reviews = new List<ReviewModel>();
            Random rand = new Random();

            for (int i = 1; i <= 100; i++)
            {
                string str = "";
                for (int j = 0; j < 7; j++)
                {
                    int randValue;
                    char letter;
                    randValue = rand.Next(0, 26);
                    letter = Convert.ToChar(randValue + 65);
                    str = str + letter;
                }
                reviews.Add(new ReviewModel
                {
                    Id = i,
                    Description = str,
                });
            }
            return reviews;
        }
    }
}
