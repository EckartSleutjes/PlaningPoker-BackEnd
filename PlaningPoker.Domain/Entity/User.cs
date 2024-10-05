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
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }
    }
}
