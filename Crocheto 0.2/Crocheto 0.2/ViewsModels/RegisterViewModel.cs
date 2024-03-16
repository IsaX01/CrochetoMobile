using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.ViewsModels
{
    public class RegisterViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool HasFingerprintRegistered { get; set; }
        public string SubscriptionType { get; set; }

        public bool IsLoading { get; set; }
    }

}
