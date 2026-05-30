using Infirmary.Models;
using Infirmary.Models.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Dynamic;

namespace Infirmary.Services
{
    public class GenericService : CrudService<Generic>
    {
        private readonly Dictionary<string, CrudService<BaseEntity>> _services = new Dictionary<string, CrudService<BaseEntity>>();
        private  readonly IServiceProvider _serviceProvider;
        public GenericService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;




            Create(new Generic
            {
                Id = 1,
                DataGridTitle = "حسابداری",
                ServiceName = "Accounting",
                DataGridNewRowButtonTitle = "ایجاد",
                Fields = new Dictionary<Property, object>()
                {
                    {new Property("FirstName","نام"),"" },
                    {new Property("LastName","نام خانوادگی"),"" }
                }
            });



            /*foreach (var item in _entityCache)
            {
                dynamic dynEntity = new ExpandoObject();
                ((BaseEntity)dynEntity).Id = item.Value.Id;
                var dict = (IDictionary<string, object>)dynEntity;
                foreach (var field in (item.Value).Fields)
                {
                    dict.Add(field.Key, item.Value);
                }
                _services.Add(item.Value.ModelName, serviceProvider.GetService<CrudService<BaseEntity>>());
            }*/
        }
        public override int Create(Generic entity)
        {
            _services.Add(entity.ServiceName, _serviceProvider.GetService<CrudService<BaseEntity>>());
            return base.Create(entity);
        }



        public virtual int Create(string serviceName,BaseEntity entity)
        {
            entity.Id = new Random().Next();
            _services[serviceName].Create(entity);
            return entity.Id;
        }
        public virtual List<BaseEntity> Read(string serviceName)
        {
            return _services[serviceName].Read();
        }
        public virtual BaseEntity Read(string serviceName, int id)
        {
            return _services[serviceName].Read(id);
        }

        public virtual void Update(string serviceName, int Id, BaseEntity entity)
        {
            _services[serviceName].Update(Id,entity);
        }
        public virtual void Delete(string serviceName, int id)
        {
            _services[serviceName].Delete(id);
        }
    }
}
