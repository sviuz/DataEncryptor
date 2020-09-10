using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class DataIdentityUser
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}