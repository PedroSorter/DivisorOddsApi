using Flunt.Notifications;
using System;

namespace DivisorOdds.Domain.Entities
{
    public class BaseEntity : Notifiable
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; protected set; }

        public void UpdateId(Guid id)
        {
            if (id == Guid.Empty)
                id = Guid.NewGuid();

            Id = id;
        }
    }
}
