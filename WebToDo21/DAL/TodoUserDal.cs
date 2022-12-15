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

        public static int CreateUser(TodoUser tdUser)
        {
            string query = @"insert into users.todoUser values(@userName, @userPassword, @userRole)
                            select cast(scope_identity() as int)";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@userName", tdUser.UserName);
                        comm.Parameters.AddWithValue("@userPassword", tdUser.UserPassword);
                        comm.Parameters.AddWithValue("@userRole", tdUser.UserRole);
                        conn.Open();
                        return (int) comm.ExecuteScalar();
                    }
                    catch (System.Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int UpdateUser(TodoUser tdUser)
        {
            string query = @"update users.todoUser set userPassword=@userPassword, userRole=@userRole
                            where userId=@id";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@userPassword", tdUser.UserPassword);
                        comm.Parameters.AddWithValue("@userRole", tdUser.UserRole);
                        comm.Parameters.AddWithValue("@id", tdUser.UserId);
                        conn.Open();
                        return comm.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int DeleteUser(TodoUser tdUser)
        {
            string query = "delete users.todoUser where userId=@id";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@id", tdUser.UserId);
                        conn.Open();
                        return comm.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        return -1;
                    }
                }
            }
        }
    }
}