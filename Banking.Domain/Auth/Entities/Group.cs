using Common;

namespace Banking.Domain.Auth.Entities
{
    public class Group : Entity
    {
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }

        public Group()
        {
        }
    }
}
