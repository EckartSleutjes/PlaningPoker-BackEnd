namespace PlaningPoker.Domain.Entity
{
    public class User : Entity
    {
        private User() { }
        public User(string name, string email, byte[] passwordHash, byte[] passwordSalt) 
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public void Delete()
        {
            DeletedDate = DateTime.Now;
            IsDeleted = true;
        }
    }
}
