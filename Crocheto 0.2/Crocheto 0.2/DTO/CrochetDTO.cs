using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.DTO
{
    public class CrochetDTO
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Subtitle { get; set; }
        public string? StatusText { get; set; }
        public byte[]? PdfFile { get; set; }
        public string UserId { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
