using RedBadgeFinal.Data;
using RedBadgeFinal.Models;
using RedBadgeFinal.Models.ServiceNoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services
{
    public class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Content = model.Content,
                    //Services = model.Services,
                    //ServiceNote = model.ServiceNote,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Notes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new NoteListItem
                        {
                            NoteId = e.NoteId,
                            Content = e.Content,
                            //ServiceNote = entity.ServiceNote,
                            CreatedUtc = e.CreatedUtc,
                            Services = e.Services.Select(s => s.Service.ServiceName).ToList()
                        }
            );
                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == id && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Content = entity.Content,
                        //ServiceNote = entity.ServiceNote,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                        Services = entity.Services.Select(s => s.Service.ServiceName).ToList()
                    };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Content = model.Content;
                //entity.ServiceNote = model.ServiceNote;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool AddService(ServiceNoteCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new ServiceNote()
                {
                    NoteId = model.NoteId,
                    ServiceId = model.ServiceId
                };

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
