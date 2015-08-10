using System;
using System.Collections.Generic;
using System.Text;
using Sqo;

namespace SiagodbTest.DependencyInterfaces
{
    public interface ISiaqoDatabase
    {
        ISiaqodb GetInstant();
    }
}
