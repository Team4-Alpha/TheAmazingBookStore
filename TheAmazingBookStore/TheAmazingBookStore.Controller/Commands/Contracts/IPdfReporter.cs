using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheAmazingBookStore.Controller.Commands.Contracts
{
   public interface IPdfReporter
    {
        string Execute(IList<string> parameters);

    }
}
