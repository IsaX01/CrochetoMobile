using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.ViewsModels
{
    public class CrochetNewViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        public string StatusText { get; set; }
        public byte[]? PdfFile { get; set; }
        public string UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
