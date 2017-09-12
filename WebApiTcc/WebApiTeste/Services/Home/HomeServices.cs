using System;
using WebApiTcc.Repository.Home;
using WebApiTcc.ViewModel.Home;

namespace WebApiTcc.Services.Home
{
    public class HomeServices :IHomeServices
    {
        private readonly IHomeRepository _homeRepository;


        public HomeServices(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public HomeViewModel Get()
        {
            try
            {
                return _homeRepository.Get();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
