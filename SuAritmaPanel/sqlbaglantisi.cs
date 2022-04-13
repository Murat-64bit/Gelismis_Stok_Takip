using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SuAritmaPanel
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source = 91.151.90.95;Initial Catalog = DB-1742; User Id=SuAritmaSQL; password=V:cCJjaw:W]SpWUSNGhg+");
            baglan.Open();
            return baglan;
        }
    }
}
