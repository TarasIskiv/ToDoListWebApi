using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    interface INoteService
    {
        public IEnumerable<NoteDto> GetAll(int id);

        public NoteDto GetById(int id);

        public void Create(CreateNoteDto dto, int id);

        public void Delete(int id);

        public void Update(UpdateNoteDto dto);

    }
}
