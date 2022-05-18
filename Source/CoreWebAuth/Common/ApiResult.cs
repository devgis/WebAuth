using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAuth.Common
{
    public class ApiResult
    {
        public int code
        {
            get;
            set;
        }
        public string errmessge
        {
            get;
            set;
        }

        public object data
        {
            get;
            set;
        }
    }
}
