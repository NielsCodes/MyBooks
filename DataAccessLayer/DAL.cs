using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InleverOpdracht1.Models;

namespace InleverOpdracht1.DataAccessLayer
{
    public class DAL
    {

        private string connectionString = "Data Source=NIELSKERSICAF62;Initial Catalog=MyBooks;Integrated Security=True;Pooling=False";

        private SingleBook CreateBookFromDB(IDataRecord record)
        {
            var id = record.GetInt32(0);
            var title = record.GetString(1);
            var author = record.GetString(2);
            var genre = record.IsDBNull(3) ? null : record.GetString(3);
            var series = record.IsDBNull(4) ? null : record.GetString(4);
            var language = record.IsDBNull(5) ? null : record.GetString(5);
            var edition = record.IsDBNull(6) ? null : record.GetString(6);
            var publisher = record.IsDBNull(7) ? null : record.GetString(7);
            var pages = record.IsDBNull(8) ? 0 : record.GetInt32(8);
            var cover = record.IsDBNull(9) ? null : record.GetString(9);
            var coverType = record.IsDBNull(10) ? null : record.GetString(10);
            var isbn = record.IsDBNull(11) ? null : record.GetString(11);
            var releaseDate = record.IsDBNull(12) ? null : record.GetString(12);
            var purchaseDate = record.IsDBNull(13) ? null : record.GetString(13);
            var price = record.IsDBNull(14) ? 0 : record.GetInt32(14);
            var purchasePrice = record.IsDBNull(15) ? 0 : record.GetInt32(15);

            var book =
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
                    );

            return book;
        }

        public List<SingleBook> GetBooks()
        {

            List<SingleBook> books = new List<SingleBook>();
            
            using(var connection = new SqlConnection(connectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = 
                        "SELECT b.id, b.title, a.name author, g.name genre, s.name series, l.name language, b.edition, p.name publsher, b.pages, b.cover, c.name coverType, b.isbn, b.releaseDate, b.purchaseDate, b.price, b.purchasePrice " +
                        "FROM Books b " +
                        "INNER JOIN Authors     a ON b.authorId = a.id " +
                        "INNER JOIN Genres      g ON b.genreId = g.id " +
                        "INNER JOIN Series      s ON b.seriesId = s.id " +
                        "INNER JOIN Languages   l ON b.languageId = l.id " +
                        "INNER JOIN Publishers  p ON b.publisherId = p.id " +
                        "INNER JOIN CoverTypes  c ON b.coverTypeId = c.id " +
                        "ORDER BY b.id";

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            books.Add(CreateBookFromDB(reader));

                        }
                    }
                }
            }

            return books;

        }

        public SingleBook GetBook(int id)
        {
            SingleBook book = null;

            using(var connection = new SqlConnection())
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText =
                        "SELECT b.id, b.title, a.name author, g.name genre, s.name series, l.name language, b.edition, p.name publsher, b.pages, b.cover, c.name coverType, b.isbn, b.releaseDate, b.purchaseDate, b.price, b.purchasePrice " +
                        "FROM Books b " +
                        "INNER JOIN Authors     a ON b.authorId = a.id " +
                        "INNER JOIN Genres      g ON b.genreId = g.id " +
                        "INNER JOIN Series      s ON b.seriesId = s.id " +
                        "INNER JOIN Languages   l ON b.languageId = l.id " +
                        "INNER JOIN Publishers  p ON b.publisherId = p.id " +
                        "INNER JOIN CoverTypes  c ON b.coverTypeId = c.id " +
                        "WHERE b.id = @bookId";
                    cmd.Parameters.AddWithValue("bookId", id);

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            book = CreateBookFromDB(reader);
                        }
                    }
                }
            }

            return book;
        }

        public bool CheckUser(string username, string password)
        {
            var userFound = false;
            var resultCount = 0;

            using (var connection = new SqlConnection())
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT id FROM Users WHERE username=@username AND password=@password";
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("password", password);

                    using(var reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            resultCount++;
                        }
                    }
                }
            }

            if(resultCount == 1)
            {
                userFound = true;
            }

            return userFound;
        }

    }
}