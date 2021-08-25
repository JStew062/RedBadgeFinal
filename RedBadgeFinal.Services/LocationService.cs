using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    LocationId = model.LocationId,
                    City = model.City,
                    County = model.County,
                    ZipCode = model.ZipCode
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Locations
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new LocationListItem
                        {
                            LocationId = e.LocationId,
                            City = e.City,
                            County = e.County,
                            ZipCode = e.ZipCode
                        }
            );
                return query.ToArray();
            }
        }
        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == id);
                return
                    new LocationDetail
                    {
                        LocationId = entity.LocationId,
                        City = entity.City,
                        County = entity.County,
                        ZipCode = entity.ZipCode

                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == model.LocationId);

                entity.LocationId = model.LocationId;
                entity.City = model.City;
                entity.County = model.County;
                entity.ZipCode = model.ZipCode;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == locationId);

                ctx.Locations.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
