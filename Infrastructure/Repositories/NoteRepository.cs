using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ToDoDBContext _context;

        public NoteRepository(ToDoDBContext context)
        {
            _context = context;
        }
        public void AddNewNote(Note note, int id)
        {
            note.UserId = id;
            note.Created = DateTime.UtcNow;
            note.LastModified = DateTime.UtcNow;
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void DeleteNote(Note note)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAllNotes(int userId)
        {
            return _context.Notes.ToList().Where(x => x.UserId == userId);
        }

        public Note GetNoteById(int id)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Note note)
        {
            var currentNote = _context.Notes.ToList().Where(x => x.Id == note.Id).SingleOrDefault();
            if(currentNote == null)
            {
                throw new Exception("Not Found");
            }

            currentNote.Content = note.Content;
            currentNote.LastModified = DateTime.UtcNow;
            //_context.Notes.Update(note);
            _context.SaveChanges();
        }

    }
}
