using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.UnidadeNegocio
{
    public interface IUnidadeNegocioService
    {
        IEnumerable<UnidadeNegocio> GetAll();
    }
}
