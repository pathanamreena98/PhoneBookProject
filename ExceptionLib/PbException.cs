using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLib
{
    public class PbException:Exception
    {
        public PbException(string errMsg) : base(errMsg)
        {

        }
    }
}
