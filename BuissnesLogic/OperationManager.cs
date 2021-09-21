using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vezba26062021.BuissnesLogic
{
    public class OperationManager
    {
        private static OperationManager _instance;

        public static OperationManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new OperationManager();
                }
                return _instance;
            }
        }

        public OperationResult ExecuteOperation(Operation operation)
        {
            try
            {
                return operation.Execute();
            }
            catch (Exception)
            {
                return new OperationResult
                {
                    Errors = new List<string>
                    {
                        "Doslo je do greske, obratite se administratoru!"
                    }
                };
            }
        }
    }
}
