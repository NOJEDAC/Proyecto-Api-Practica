using Common;

namespace Banking.Domain.Auth.Entities
{
    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool Active { get; set; }

        public User()
        {
        }
    }
}
