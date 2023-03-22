namespace DrillCRUD.Models
{
    public class DrillBlockFullDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<DrillBlockPointDTO> DrillBlockPoints { get; set; }
        public List<HoleFullDTO> Holes { get; set; }
    }
}
