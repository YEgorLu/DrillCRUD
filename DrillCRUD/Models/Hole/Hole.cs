using DrillCRUD.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrillCRUD.Models
{
    public class Hole: Entity
    {
        public string Name { get; set; }

        public float DEPTH { get; set; }

        [ForeignKey(nameof(DrillBlock))]
        public int DrillBlockId { get; set; }

        public DrillBlock DrillBlock { get; set; }

        public HolePoint HolePoint { get; set; }

    }
}
