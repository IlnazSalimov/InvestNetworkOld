using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestNetwork.Application.Core
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
