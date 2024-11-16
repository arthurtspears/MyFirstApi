namespace MyFirstApi.EFCore.Abstract
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
