using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warhorn.API.Types
{
    public class PageInfo
    {
        public string startCursor;

        public string endCursor;

        public bool? hasNextPage;

        public bool? hasPreviousPage;
    }
}
