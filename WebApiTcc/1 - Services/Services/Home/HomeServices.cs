using Data.Repository.Home;
using System.Collections.Generic;

namespace Data.Services.Home
{
    public class HomeServices :IHomeServices
    {
        private readonly IHomeRepository _homeRepository;


        public HomeServices(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }


        public IEnumerable<Usuario.Usuario> GetBd()
        {
           return _homeRepository.GetBd();
        }
    }
}
