using CommonDomain.Model;
using System;

namespace ReviewsManagement.Domain
{
    public class Review : Entity<int>
    {
        public string Text { get; private set; }
        public int Stars { get; private set; }
        public Customer CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Review(Customer createdBy, int stars) : this(createdBy, stars, null)
        { }

        public Review(Customer createdBy, int stars, string text)
        {
            CreatedBy = createdBy;
            if (stars < 0 || stars > 5)
                throw new ArgumentOutOfRangeException(nameof(stars), "Stars must be equal or more than 0, and less then 6.");

            Text = text;
            CreatedAt = DateTime.Now;
        }
    }
}
