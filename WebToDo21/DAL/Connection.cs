using System.Data.SqlClient;

namespace WebToDo21.DAL
{
    static class Connection
    {
        public static string CnnMyTodoDb {
            get{
                SqlConnectionStringBuilder cnnSb = new SqlConnectionStringBuilder();
                cnnSb.DataSource = ".\\sqlexpress";
                cnnSb.InitialCatalog = "MyTodoDb";
                cnnSb.IntegratedSecurity = true;

                return cnnSb.ToString();
            }
        }
    }
}