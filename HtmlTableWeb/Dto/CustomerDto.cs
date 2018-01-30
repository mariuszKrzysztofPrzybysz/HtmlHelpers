using System.ComponentModel.DataAnnotations;
using HtmlTable.Attributes;
using HtmlTableWeb.Models;

namespace HtmlTableWeb.Dto
{
    [DisplayTable(HasHeading = false)]
    public class CustomerDto
    {
        private long _customerId;

        [Display(Name = "Id")]
        public long CustomerId
        {
            get => _customerId.GetHashCode();

            set => _customerId = value;
        }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}