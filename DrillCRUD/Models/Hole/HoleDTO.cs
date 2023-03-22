using System.ComponentModel.DataAnnotations;

namespace DrillCRUD.Models
{
    public class HoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float DEPTH { get; set; }
        public int DrillBlockId { get; set; }
    }
}
