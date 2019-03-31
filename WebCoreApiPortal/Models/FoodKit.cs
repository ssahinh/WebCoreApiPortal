using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCoreApiPortal.Models
{
    [Table("NutritionFacts")]
    public class FoodKit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public double Piece { get; set; }
        public string Describe { get; set; }
        public string ImageUrl { get; set; }
        public int Energy { get; set; }
        public double Carbohydrate { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Lif { get; set; }
        public double Cholesterol { get; set; }
        public double Sodium { get; set; }
        public double Potassium { get; set; }
        public double Calcium { get; set; }
        public double VitaminA { get; set; }
        public double VitaminC { get; set; }
        public double Iron { get; set; }
        public double Rate { get; set; }
    }
}
