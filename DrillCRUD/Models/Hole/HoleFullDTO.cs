using System.ComponentModel.DataAnnotations.Schema;

namespace DrillCRUD.Models
{
    public class HoleFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float DEPTH { get; set; }

        [ForeignKey(nameof(DrillBlock))]
        public int DrillBlockId { get; set; }

        public HolePointDTO HolePoint { get; set; }
    }
}
