using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class ServiceService

    {
        private readonly Guid _userId;

        public ServiceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateService(ServiceCreate model)
        {
            var entity =
                new Service()
                {
                    //OwnerId = _userId,
                    ServiceName = model.ServiceName,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Services
                    //.Where(e => e.ServiceId == _serviceId)
                    .Select(
                        e =>
                        new ServiceListItem
                        {
                            ServiceId = e.ServiceId,
                            CreatedUtc = e.CreatedUtc
                        }
            );
                return query.ToArray();
            }
        }

        public ServiceDetail GetServiceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == id);
                return
                    new ServiceDetail
                    {
                        ServiceId = entity.ServiceId,
                        ServiceName = entity.ServiceName
                        //ServiceNote = entity.ServiceNote,
                    };
            }
        }

        public bool UpdateService(ServiceEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == model.ServiceId);

                entity.ServiceName = model.ServiceName;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteService(int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Services
                    .Single(e => e.ServiceId == serviceId);

                ctx.Services.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}



