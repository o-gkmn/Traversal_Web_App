using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Guide
    {
        [Key]
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? TwitterURL { get; set; }
        public string? InstagramURL { get; set; }
        public bool Status { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}
