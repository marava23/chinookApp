using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vezba26062021.DataAccess;

namespace Vezba26062021.BuissnesLogic
{
    public abstract class EntityOperation : Operation
    {
        private ChinookEntities _entites;

        protected ChinookEntities Entities { get => _entites; }

        protected EntityOperation()
        {
            _entites = new ChinookEntities();
        }
    }
}
