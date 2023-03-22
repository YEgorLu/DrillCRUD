using DrillCRUD.Models.Abstract;

namespace DrillCRUD.Models
{
    public class DrillBlock: Entity
    {
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<DrillBlockPoint> DrillBlockPoints { get; set; }
        public List<Hole> Holes { get; set; }
    }
}
