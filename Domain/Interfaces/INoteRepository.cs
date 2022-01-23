using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        public void AddNewNote(Note note);
        public void DeleteNote(Note note);
        public IEnumerable<Note> GetAllNotes();
        public Note GetNoteById(int id);
        public void Update(Note note);

    }
}
