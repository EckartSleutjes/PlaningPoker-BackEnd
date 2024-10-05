namespace PlaningPoker.Domain.Entity
{
    public class User : Entity
    {
        private User() { }
        public User(string name, string lastName, string email, string password, string passwordSalt) 
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            PasswordSalt = passwordSalt;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
    }
}
