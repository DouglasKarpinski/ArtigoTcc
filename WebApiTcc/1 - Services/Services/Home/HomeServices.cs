using Data.Repository.Home;
using System;
using WebApiTcc.Services.Home;

namespace Data.Services.Home
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
