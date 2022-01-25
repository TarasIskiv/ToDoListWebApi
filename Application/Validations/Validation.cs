using Application.DTO;
using Application.Errors;
using Application.Exceptions;
using Application.TokenData.Active;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public static class Validation
    {

        public static int UserTokenValidation(this string token)
        {
            var currentLoginedUsers = new ActiveLoginedUsers();
            var user = currentLoginedUsers.GetAllLoginedUsers().ToList().Where(x => x.Token == token).FirstOrDefault();

            if (user == null)
            {
                throw new TokenException("Your Token is not valid");
            }

            return user.Id;
        }

        public static void NoteValidation(this IEnumerable<NoteDto> dto, int id)
        {
            var note = dto.ToList().Where(x => x.Id == id).FirstOrDefault();
            if (note == null)
            {
                throw new NoteException("Bad Note unique id");
            }
        }
    }
}
