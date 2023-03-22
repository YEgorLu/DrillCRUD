using DrillCRUD.Models.Abstract;

namespace DrillCRUD.Models
{
    public class DrillBlockPointDTO: Point
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public int DrillBlockId { get; set; }
    }
}
