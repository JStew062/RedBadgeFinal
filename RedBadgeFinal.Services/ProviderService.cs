using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class ProviderService
    {
    
        private readonly Guid _userId;

        public ProviderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProvider(ProviderCreate model)
        {
            var entity =
                new Provider()
                {
                    //OwnerId = _userId,
                    ProvName = model.ProvName,
                    LocationId = model.LocationId,
                    ServiceName = model.ServiceName
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Providers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProviderListItem> GetProviders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Providers
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProviderListItem
                        {
                            ProvName = e.ProvName,
                            LocationId = e.LocationId,
                            ServiceName = e.ServiceName
                        }
            );
                return query.ToArray();
            }
        }

        public ProviderDetail GetProviderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProvId == id);
                return
                    new ProviderDetail
                    {
                        ProvName = entity.ProvName,
                        LocationId = entity.LocationId,
                        ServiceName = entity.ServiceName

                    };
            }
        }

        public bool UpdateProvider(ProviderEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProvId == model.ProvId);

                entity.ProvId = model.ProvId;
                entity.ProvName = model.ProvName;
                entity.LocationId = model.LocationId;
                entity.ServiceName = model.ServiceName;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteProvider(int provId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProvId == provId);

                ctx.Providers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

