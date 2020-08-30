using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class DataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
