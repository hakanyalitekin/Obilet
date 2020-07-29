using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Abstract
{
    public interface IRestApiService
    {
         string Post<T>(string Url, T model);
    }
}
