using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataModels.Entities
{
    [Table("Models")]
    public class DataBaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SecretValue { get; set; }

    }
}
