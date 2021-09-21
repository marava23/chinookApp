using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Vezba26062021.BuissnesLogic.Albums
{
    public class AlbumDTO : DTO
    {
        [DisplayName("Album name")]
        public string Title { get; set; }
        [Browsable(false)]
        public int ArtistId { get; set; }
        [DisplayName("Number of songs")]
        public int TracksCount { get; set; }
        [DisplayName("Artist")]
        public string ArtistName { get; set; }
    }
}
