using Data.Services.Usuario;
using System.Collections.Generic;

namespace Data.Repository.Home
{
    public interface IHomeRepository
    {
        IEnumerable<Usuario> GetBd();
    }
}
