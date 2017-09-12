using System.Collections.Generic;
using WebApiTcc.ViewModel.Usuario;

namespace WebApiTcc.ViewModel.Home
{
    public class HomeViewModel
    {
        public IEnumerable<UsuarioViewModel> Usuario{ get; set; }
    }
}
