using System;

namespace HtmlTableWeb.Models
{
    public class Customer : IComparable
    {
        public long CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case Customer other:
                    return this.CustomerId.CompareTo(other.CustomerId);
            }

            throw new ArgumentException("Object is not a Customer");
        }
    }
}