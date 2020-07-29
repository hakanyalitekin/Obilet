using Obilet.Entities.Concrete.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface ISessionService
    {
         Result GetSession();
    }
}
