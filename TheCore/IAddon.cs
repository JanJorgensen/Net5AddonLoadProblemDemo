using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCore
{
    public interface IAddon
    {
        object Action();
        System.Type GetSomeType();
    }
}
