using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crocheto_0._2.DTO
{
    public class UserDTO
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Token { get; set; }
        public bool HasFingerprintRegistered { get; set; }
        public string SubscriptionType { get; set; }
    }
}
