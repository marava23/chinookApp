using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic.Artist
{
    public class SelectArtistOperation : EntityOperation
    {
        public override OperationResult Execute()
        {
            var artist = Entities.Artists.Select(x => new ArtistDTO
            {
                Id = x.ArtistId,
                Name = x.Name
            }).ToList();
            return new OperationResult
            {
                Data = artist
            };
        }
    }
}
