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
                    //ProvId = model.ProvId,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Services.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public void AddProviderToService(int provId, int serviceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundProvider = ctx.Providers.Single(p => p.ProvId == provId);
                var foundService = ctx.Services.Single(s => s.ServiceId == serviceId);
                foundService.ListOfProviders.Add(foundProvider);
                var testing = ctx.SaveChanges();
            }
        }

        public IEnumerable<ServiceListItem> GetServices()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Services
                    //.Where(e => e.OwnerId == _OwnerId)
                    .Select(
                        e =>
                        new ServiceListItem
                        {
                            ServiceId = e.ServiceId,
                            ServiceName = e.ServiceName,
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
                                //ServiceNote = entity.ServiceNote
                            };
            }
        }


        /* public ServiceDetail GetServiceById(int id)
         {
             using (var ctx = new ApplicationDbContext())
             {
                 var entity =
                     ctx
                     .Services
                     .SingleOrDefault(e => e.ServiceId == id);
                 var service = new ServiceDetail()
                 {
                     ServiceId = entity.ServiceId,
                     ServiceName = entity.ServiceName,
                     //ServiceNote = entity.ServiceNote
                     Notes = entity.Notes.Select(e => new Models.NoteListItem()
                     {
                         Content = e.Note.Content,
                         //ServiceNote = e.Service.ServiceId + " " + e.Service.ServiceName,
                         CreatedUtc = e.Note.CreatedUtc,
                         NoteId = e.NoteId
                     }).ToList()
                 };
             }
         }*/


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



