using System.Collections.Generic;

namespace Data.Services.Home
{
    public interface IHomeRepository
    {
        IEnumerable<Usuario.Usuario> GetBd();
    }
}
