using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic.Albums
{
    public class AddNewAlbumOperation : EntityOperation
    {
        private readonly AlbumDTO _dto;
        public AddNewAlbumOperation(AlbumDTO dto)
        {
            _dto = dto;
        }
        public override OperationResult Execute()
        {
            var result = new OperationResult();

            if(Entities.Albums.Any(x=> x.ArtistId == _dto.ArtistId && x.Title == _dto.Title))
            {
                result.Errors.Add("Takav album vec postoji!");
                return result;
            }
            if(!Entities.Albums.Any(x=> x.ArtistId == _dto.ArtistId))
            {
                result.Errors.Add("Takav izvodjac ne postoji!");
            }

            var albumId = Entities.Albums.Max(x => x.AlbumId);

            Entities.Albums.Add(new DataAccess.Album
            {
                AlbumId = albumId + 1,
                ArtistId = _dto.ArtistId,
                Title = _dto.Title
            });

            Entities.SaveChanges();

            return result;
        }
    }
}
