using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    ClientId = model.ClientId,
                    ClientName = model.ClientName,
                    LocationId = model.LocationId,
                    CaseMgr = model.CaseMgr
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientListItem> GetClients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Clients
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ClientListItem
                        {
                            ClientId = e.ClientId,
                            ClientName = e.ClientName,
                            LocationId = e.LocationId,
                            CaseMgr = e.CaseMgr,
                            //Content = e.Content
                        }
            );
                return query.ToArray();
            }
        }
        public ClientDetail GetClientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientId == id);
                return
                    new ClientDetail
                    {
                        ClientId = entity.ClientId,
                        ClientName = entity.ClientName,
                        LocationId = entity.LocationId,
                        CaseMgr = entity.CaseMgr
                     };
            }
        }

        public bool UpdateClient(ClientEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.ClientId == model.ClientId);

                entity.ClientId = model.ClientId;
                entity.ClientName = model.ClientName;
                entity.LocationId = model.LocationId;
                entity.CaseMgr = model.CaseMgr;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Clients
                    .Single(e => e.LocationId == clientId);

                ctx.Clients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

