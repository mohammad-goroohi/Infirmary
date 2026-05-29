using Infirmary.Models.Shared;
using Infirmary.Models.Users;

namespace Infirmary.Services
{
    public class CrudService<Entity> where Entity : BaseEntity
    {
        protected readonly Dictionary<int, Entity> _entityCache = new Dictionary<int, Entity>();
        public virtual int Create(Entity entity)
        {
            entity.Id = new Random().Next();
            _entityCache.Add(entity.Id, entity);
            return entity.Id;
        }
        public virtual List<Entity> Read()
        {
            return _entityCache.Values.ToList();
        }
        public virtual Entity Read(int id)
        {
            return _entityCache[id];
        }
        
        public virtual void Update(int Id,Entity entity)
        {
            _entityCache[Id] = entity;
        }
        public virtual void Delete(int id)
        {
            _entityCache.Remove(id);
        }
    }
}
