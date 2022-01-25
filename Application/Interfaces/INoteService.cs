using Application.DTO;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INoteService
    {
        public IEnumerable<NoteDto> GetAll(int id);

        public NoteDto GetById(int id);

        public void Create(CreateNoteDto dto, int id);

        public void Delete(int id);

        public void Update(UpdateNoteDto dto);

    }
}
