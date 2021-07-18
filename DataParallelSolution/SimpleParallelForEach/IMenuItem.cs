using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public interface IMenuItem
    {
        int Index { get; set; }
        string Name { get; }
        void Run();
    }
}
