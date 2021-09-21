using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic.Albums
{
    public class SelectAlbumOperation : EntityOperation
    {
        public string Keyword { get; set; }
        public override OperationResult Execute()
        {
            var query = Entities.Albums.AsQueryable();
            if (Keyword != null)
            {
                query = query.Where(x => x.Title.ToLower().Contains(Keyword.ToLower()));
            }
            var albums = query.Select(x => new AlbumDTO
            {
                Id = x.AlbumId,
                ArtistId = x.ArtistId,
                Title = x.Title,
                TracksCount = x.Tracks.Count,
                ArtistName = x.Artist.Name
            }).ToList();

            return new OperationResult
            {
                Data = albums
            };
        }
    }
}
