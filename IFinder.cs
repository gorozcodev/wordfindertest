using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wordfinder
{
    public interface IFinder
    {
        IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
