using DrillCRUD.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrillCRUD.Models
{
    public class HolePoint : Point
    {
        [ForeignKey(nameof(Hole))]
        public int HoleId { get; set; }

        public Hole Hole { get; set; }
    }
}
