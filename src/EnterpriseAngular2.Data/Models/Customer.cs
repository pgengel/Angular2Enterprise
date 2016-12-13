using System.ComponentModel.DataAnnotations;

namespace EnterpriseAngular2.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}