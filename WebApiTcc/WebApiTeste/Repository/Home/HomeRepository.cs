using WebApiTcc.Helpers.DataBaseInvoker;
using WebApiTcc.ViewModel;

namespace WebApiTcc.Repository.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly IDatabaseInvoker _databaseInvoker;


        private enum Procedures
        {
            
        }
        public HomeRepository(IDatabaseInvoker databaseInvoker)
        {
            _databaseInvoker = databaseInvoker;
        }

        public HomeViewModel Get()
        {
           _databaseInvoker.BeginNewStatement("");
        }
    }
}
