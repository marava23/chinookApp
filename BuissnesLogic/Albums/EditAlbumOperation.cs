using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic.Albums
{
    public class EditAlbumOperation : EntityOperation
    {
        private AlbumDTO _dto;
        public EditAlbumOperation(AlbumDTO dto)
        {
            if(dto == null)
            {
                throw new NullReferenceException();
            }
            this._dto = dto;
        }
        public override OperationResult Execute()
        {
            var albumToEdit = Entities.Albums.Find(_dto.Id);
            var result = new OperationResult();
            if(albumToEdit == null)
            {
                result.Errors.Add("Nismo nasli takav album!");
            }
            albumToEdit.ArtistId = _dto.ArtistId;
            albumToEdit.Title = _dto.Title;
            albumToEdit.AlbumId = _dto.Id;

            Entities.SaveChanges();
            return result;
        }
    }
}
