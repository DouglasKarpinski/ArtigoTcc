using System.Collections.Generic;

namespace Data.Services.Home
{
    public interface IHomeServices
    {
        IEnumerable<Usuario.Usuario> GetBd();
    }
}
