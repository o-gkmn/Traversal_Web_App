namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class AnnouncementUpdateDto
    {
        public int AnnouncementID { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Date { get; set; }
    }
}
