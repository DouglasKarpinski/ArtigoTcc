using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Usuario Post(Usuario usuario)
        {
            try
            {
                var retorno = _loginRepository.GetUser(usuario.Nome, usuario.Senha);

                return retorno;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
