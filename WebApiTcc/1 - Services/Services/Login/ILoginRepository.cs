using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Login
{
    public interface ILoginRepository
    {
        Usuario GetUser(string nome, string senha);
    }
}
