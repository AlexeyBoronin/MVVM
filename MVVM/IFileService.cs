using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    internal interface IFileService
    {
        List<Phone> Open(string filename);
        void Save (string filename, List<Phone> phoneList);
    }
}
