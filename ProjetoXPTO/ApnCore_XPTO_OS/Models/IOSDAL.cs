using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApnCore_XPTO_OS.Models
{
    public interface IOSDAL
    {
        IEnumerable<OS> GetAllOSs();
        void AddOS(OS os);
        void UpdateOS(OS os);
        OS GetOS(int? num_os);
        void DeleteOS(int? num_os);

    }
}
