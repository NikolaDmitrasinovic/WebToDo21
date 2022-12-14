using System.Collections.Generic;
using System.Data.SqlClient;
using WebToDo21.Models;

namespace WebToDo21.DAL
{
    static class TodoCardDal
    {
        public static List<TodoCard> ReturnCards()
        {
            string query = "select * from todo.TodoCard";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        List<TodoCard> cardList = new List<TodoCard>();
                        conn.Open();
                        SqlDataReader dr = comm.ExecuteReader();
                        while (dr.Read())
                        {
                            TodoCard tdObj = new TodoCard{
                                CardId = dr.GetInt32(0),
                                UserId = dr.GetInt32(1),
                                Title = dr.GetString(2),
                                Content = dr[3].ToString(),
                                CardStatus = dr.GetBoolean(4)
                            };
                            cardList.Add(tdObj);
                        }
                        return cardList;
                    }
                    catch (System.Exception)
                    {
                        return null;
                    }
                }
            }
        }

        public static int CreateNewCard(TodoCard tdCard)
        {
            string query = @"insert into todo.TodoCard(userId, title, content) values(@userId, @title, @content)
                            select cast(scope_identity() as int)";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@userId", tdCard.UserId);
                        comm.Parameters.AddWithValue("@title", tdCard.Title);
                        comm.Parameters.AddWithValue("@content", tdCard.Content);

                        conn.Open();
                        return (int) comm.ExecuteScalar();
                    }
                    catch (System.Exception)
                    {
                        
                        throw;
                    }
                }
            }
        }

        public static int UpdateCard(TodoCard tdCard)
        {
            string query = @"update todo.TodoCard set Title=@title, Content=@content
                            where CardId = @id";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@title", tdCard.Title);
                        comm.Parameters.AddWithValue("@content", tdCard.Content);
                        comm.Parameters.AddWithValue("@id", tdCard.CardId);

                        conn.Open();
                        return (int) comm.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        return -1;
                    }
                }
            }
        }

        public static int DeleteCard(TodoCard tdCard)
        {
            string query = "delete todo.TodoCard where CardId=@id";

            using (SqlConnection conn = new SqlConnection(Connection.CnnMyTodoDb))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    try
                    {
                        comm.Parameters.AddWithValue("@id", tdCard.CardId);

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