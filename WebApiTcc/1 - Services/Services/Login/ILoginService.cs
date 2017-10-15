using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Login
{
    public interface ILoginService
    {
        Usuario Post(Usuario usuario);
    }
}
