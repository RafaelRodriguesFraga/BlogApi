namespace Pe2Api.Domain.Entities.Base
{
    public interface IBaseEntity
    {
         public Guid Id {get; set;}
         public DateTime CreatedAt {get;set;}
        void Validate();
    }
}