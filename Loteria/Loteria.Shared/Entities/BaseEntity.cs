namespace Loteria.Shared.Entities
{
    public class BaseEntity
    {
        public int Id { get; }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
