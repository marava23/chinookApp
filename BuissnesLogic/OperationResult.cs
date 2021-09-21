using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezba26062021.BuissnesLogic.Albums;

namespace Vezba26062021.BuissnesLogic
{
    public class OperationResult
    {
        public bool IsSuccessful => !Errors.Any();
        public List<string> Errors { get; set; } = new List<string>();
        public IEnumerable<DTO> Data { get; set; } = new List<DTO>();
    }
}
