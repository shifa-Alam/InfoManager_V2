using IM.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.bll.Services
{
    public abstract class BaseService : IBaseService
    {
        public abstract void Dispose();

    }
}
