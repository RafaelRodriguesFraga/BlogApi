using Blog.Domain.Notifications;
using FluentValidation.Results;

namespace Pe2Api.Domain.Entities.Base
{
    public abstract class BaseEntity : Notifiable<Notification>, IBaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }        
        public Guid Id  {get;set;}
        public DateTime CreatedAt {get;set;}

        public abstract void Validate();

        public void AddNotifications(ValidationResult validationResult)
        {
            var invalidValidation = !validationResult.IsValid;
            if(invalidValidation)
            {
                foreach(var failure in validationResult.Errors)
                {
                    AddNotification(failure.PropertyName, failure.ErrorMessage);
                }
            }
            
        }
    }
}
