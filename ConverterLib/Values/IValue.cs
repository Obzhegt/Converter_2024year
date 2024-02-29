using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLib
{
    internal interface IValue
    {
        Dictionary<string, double> Get_coef_dict();
        string Get_name();
    }
}
