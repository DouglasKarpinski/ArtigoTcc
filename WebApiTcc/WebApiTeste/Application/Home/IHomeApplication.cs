using System.Threading.Tasks;
using WebApiTcc.Models;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.Application.Home
{
    public interface IHomeApplication
    {
        //async Task Response Get();
        Response<UsuarioViewModel> GetUser(string logon, string senha);

        Response Get();
    }
}
