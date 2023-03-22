using DrillCRUD.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrillCRUD.Models
{
    public class DrillBlockPoint : Point
    {
        public int Sequence { get; set; }

        [ForeignKey(nameof(DrillBlock))]
        public int DrillBlockId { get; set; }

        public DrillBlock DrillBlock { get; set; }
    }
}
