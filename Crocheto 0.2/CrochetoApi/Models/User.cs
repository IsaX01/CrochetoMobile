namespace CrochetoApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool HasFingerprintRegistered { get; set; }
        public string SubscriptionType { get; set; }
    }
}
