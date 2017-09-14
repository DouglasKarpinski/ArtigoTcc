using System.Data.SqlClient;

namespace Data.Repository
{
    public class UI
    {
        class Program
        {
            static void Main(string[] args)
            {
                SqlConnection conection = new SqlConnection(@"data source=analisesatisfacao.database.windows.net; Integrated Security=SSPI; Initial Catalog=TCC Database;User ID=administrador; Password=Adm123**");

                conection.Open();

                /*teste no banco*/

                string strquery = "SELECT * FROM Usuario";
                SqlCommand cmdCommandSelect = new SqlCommand(strquery, conection);
                SqlDataReader dados = cmdCommandSelect.ExecuteReader();
            }
        }
    }
}
