using System.ComponentModel.DataAnnotations;

namespace ErrorAPI.DB.Entities
{
    public class Program
    {
        [Key]
        public string Name { get; set; }

        public string ContactEmail { get; set; }
    }
}