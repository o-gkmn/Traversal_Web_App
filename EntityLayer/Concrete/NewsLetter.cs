using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int NewsLetterID { get; set; }
        public string Mail { get; set; }
    }
}
