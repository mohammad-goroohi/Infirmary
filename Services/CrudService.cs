using Infirmary.Models.Shared;
using Infirmary.Models.Users;

namespace Infirmary.Services
{
    public abstract class CrudService<Entity> where Entity : BaseEntity
    {
        protected readonly Dictionary<int, Entity> _entityCache = new Dictionary<int, Entity>();
        public virtual int Create(Entity Entity)
        {
            Entity.Id = new Random().Next();
            _entityCache.Add(Entity.Id, Entity);
            return Entity.Id;
        }
        public virtual List<Entity> Read()
        {
            return _entityCache.Values.ToList();
        }
        public virtual Entity Read(int Id)
        {
            return _entityCache[Id];
        }
        
        public virtual void Update(int Id,Entity Entity)
        {
            _entityCache[Id] = Entity;
        }
        public virtual void Delete(int Id)
        {
            _entityCache.Remove(Id);
        }
    }
}
