using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreApiPortal.Models
{
    [Table("OtoService")]
    public class CarService
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Brand { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Neighborhood { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string Type { get; set; }
        public double XCoor { get; set; }
        public double YCoor { get; set; }

        [NotMapped]
        public double Distance { get; set; }
    }
}
