namespace CrochetoApi.Models
{
    public class Crochet
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Subtitle { get; set; }
        public string? StatusText { get; set; }
        public byte[]? PdfFile { get; set; }
        public string? UserId { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
