using System.Collections.Generic;
using System.Data.SqlClient;
using WebToDo21.Models;

namespace WebToDo21.DAL
{
    static class TodoUserDal
    {
        public static List<TodoUser> ReturnAllUsers()
        {
            string query = "select * from users.todoUser";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        List<TodoUser> usersList = new List<TodoUser>();
                        conn.Open();
                        SqlDataReader dr = comm.ExecuteReader();
                        while (dr.Read())
                        {
                            TodoUser tdUser = new TodoUser{
                                UserId = dr.GetInt32(0),
                                UserName = dr.GetString(1),
                                UserRole = dr.GetString(3)
                            };
                            usersList.Add(tdUser);
                        }
                        return usersList;
                    }
                    catch (System.Exception)
                    {
                        return null;
                    }
                }
            }
        }
    }
}