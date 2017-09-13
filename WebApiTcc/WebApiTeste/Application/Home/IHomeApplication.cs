using WebApiTcc.Models;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Application.Home
{
    public interface IHomeApplication
    {
        Response<UsuarioViewModel> GetUser(string logon, string senha);
    }
}
