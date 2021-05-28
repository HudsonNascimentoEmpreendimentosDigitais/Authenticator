namespace Hudson.Authenticator.Domain.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public OficialDocument UserDocument { get; set; }
    }
}
