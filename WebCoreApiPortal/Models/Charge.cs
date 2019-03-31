using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreApiPortal.Models
{
    [Table("SFChargeStation")]
    public class Charge
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string address { get; set; }
        public string usingType { get; set; }
        public string payingType { get; set; }
        public string statu { get; set; }
        public string locationType { get; set; }
        public string floor { get; set; }
        public string openingHour { get; set; }
        public string service { get; set; }
        public string reservation { get; set; }
        public string parking { get; set; }
        public string facilityNearby { get; set; }
        public string stationModel { get; set; }
        public string socket01 { get; set; }
        public string tip01 { get; set; }
        public string socket02 { get; set; }
        public string tip02 { get; set; }
        public string socket03 { get; set; }
        public string tip03 { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public double rating { get; set; }
    }
}
