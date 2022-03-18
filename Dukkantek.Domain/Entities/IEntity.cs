namespace Dukkantek.Domain.Entities
{
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
    public interface IEntity : IEntity<long>
    {

    }
}
