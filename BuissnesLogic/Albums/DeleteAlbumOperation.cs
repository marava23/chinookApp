using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic.Albums
{
    public class DeleteAlbumOperation : EntityOperation
    {
        private int _idToDelete;
        public DeleteAlbumOperation(int id)
        {
            if(id > 0)
            {
                this._idToDelete = id;
            }
            else
            {
                throw new InvalidOperationException("Id mora biti veci od 0!");
            }
        }
        public override OperationResult Execute()
        {
            var albumZaBrisanje = Entities.Albums.Find(_idToDelete);

            var result = new OperationResult();

            if (albumZaBrisanje.Tracks.Any())
            {
                result.Errors.Add("Ne mozete obrisati album koji ima pesme!");
                return result;
            }
            if (albumZaBrisanje == null)
            {
                result.Errors.Add("Izabrani album ne postoji!");
            }

            Entities.Albums.Remove(albumZaBrisanje);
            Entities.SaveChanges();
            return result;
        }
    }
}
