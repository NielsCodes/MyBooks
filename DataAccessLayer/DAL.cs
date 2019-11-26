using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InleverOpdracht1.Models;

namespace InleverOpdracht1.DataAccessLayer
{
    public class DAL
    {

        private string connectionString = "Data Source=NIELSKERSICAF62;Initial Catalog=MyBooks;Integrated Security=True;Pooling=False";
        private List<SingleBook> _books = new List<SingleBook>();

        public List<SingleBook> Books
        {
            get => _books;
            set => _books = value;
        }

        public void GetBooks()
        {
            
            _books.Clear();
            
            using(var connection = new SqlConnection(connectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM Books ORDER BY id";

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            var id = reader.GetInt32(0);
                            var title = reader.GetString(1);
                            var author = reader.GetString(2);
                            var genre = reader.IsDBNull(3) ? null : reader.GetString(3);
                            var series = reader.IsDBNull(4) ? null : reader.GetString(4);
                            var language = reader.IsDBNull(5) ? null : reader.GetString(5);
                            var edition = reader.IsDBNull(6) ? null : reader.GetString(6);
                            var publisher = reader.IsDBNull(7) ? null : reader.GetString(7);
                            var pages = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                            var cover = reader.IsDBNull(9) ? null : reader.GetString(9);
                            var coverType = reader.IsDBNull(10) ? null : reader.GetString(10);
                            var isbn = reader.IsDBNull(11) ? null : reader.GetString(11);
                            var releaseDate = reader.IsDBNull(12) ? null : reader.GetString(12);
                            var purchaseDate = reader.IsDBNull(13) ? null : reader.GetString(13);
                            var price = reader.IsDBNull(14) ? 0 : reader.GetInt32(14);
                            var purchasePrice = reader.IsDBNull(15) ? 0 : reader.GetInt32(15);
                            
                            _books.Add(
                                new SingleBook(
                                    id,
                                    title,
                                    author,
                                    genre,
                                    series,
                                    language,
                                    edition,
                                    publisher,
                                    pages,
                                    cover,
                                    coverType,
                                    isbn,
                                    releaseDate,
                                    purchaseDate,
                                    price,
                                    purchasePrice
                                    )
                                );

                        }
                    }
                }
            }
        }

    }
}