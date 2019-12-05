using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Diagnostics;
using InleverOpdracht1.Models;

namespace InleverOpdracht1.DataAccessLayer
{
    public class DAL
    {

        private string connectionString = "Data Source=NIELSKERSICAF62;Initial Catalog=MyBooks;Integrated Security=True;Pooling=False";

        private SingleBook CreateBookFromDB(IDataRecord record)
        {
            Debug.WriteLine(record);

            int id = record.GetInt32(record.GetOrdinal("id"));
            string title = record.GetString(record.GetOrdinal("title"));

            int authorId = record.GetInt32(record.GetOrdinal("authorId"));
            string authorName = record.GetString(record.GetOrdinal("author"));

            int genreId = record.GetInt32(record.GetOrdinal("genreId"));
            string genreName = record.GetString(record.GetOrdinal("genre"));

            int seriesId = record.GetInt32(record.GetOrdinal("seriesId"));
            string seriesName = record.GetString(record.GetOrdinal("series"));

            int languageId = record.GetInt32(record.GetOrdinal("languageId"));
            string languageName = record.GetString(record.GetOrdinal("language"));

            string edition = record.IsDBNull(record.GetOrdinal("edition")) ? null : record.GetString(record.GetOrdinal("edition"));

            int publisherId = record.GetInt32(record.GetOrdinal("publisherId"));
            string publisherName = record.GetString(record.GetOrdinal("publisher"));

            var pages = record.IsDBNull(record.GetOrdinal("pages")) ? 0 : record.GetInt32(record.GetOrdinal("pages"));

            var cover = record.IsDBNull(record.GetOrdinal("cover")) ? null : record.GetString(record.GetOrdinal("cover"));

            int coverTypeId = record.GetInt32(record.GetOrdinal("coverTypeId"));
            string coverTypeName = record.GetString(record.GetOrdinal("coverType"));

            var isbn = record.IsDBNull(record.GetOrdinal("isbn")) ? null : record.GetString(record.GetOrdinal("isbn"));
            var releaseDate = record.IsDBNull(record.GetOrdinal("releaseDate")) ? null : record.GetString(record.GetOrdinal("releaseDate"));
            var purchaseDate = record.IsDBNull(record.GetOrdinal("purchaseDate")) ? null : record.GetString(record.GetOrdinal("purchaseDate"));
            var price = record.IsDBNull(record.GetOrdinal("price")) ? 0 : record.GetInt32(record.GetOrdinal("price"));
            var purchasePrice = record.IsDBNull(record.GetOrdinal("purchasePrice")) ? 0 : record.GetInt32(record.GetOrdinal("purchasePrice"));

            var book =
                new SingleBook(
                    id,
                    title,
                    new MetaInfo(authorId, authorName),
                    new MetaInfo(genreId, genreName),
                    new MetaInfo(seriesId, seriesName),
                    new MetaInfo(languageId, languageName),
                    edition,
                    new MetaInfo(publisherId, publisherName),
                    pages,
                    cover,
                    new MetaInfo(coverTypeId, coverTypeName),
                    isbn,
                    releaseDate,
                    purchaseDate,
                    price,
                    purchasePrice
                    );

            return book;
        }

        public List<SingleBook> GetBooks(string searchQuery = null)
        {

            List<SingleBook> books = new List<SingleBook>();
            
            using(var connection = new SqlConnection(connectionString))
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;

                    if(searchQuery == null)
                    {
                        cmd.CommandText =
                        "SELECT b.id, b.title, b.authorId, a.name author, b.genreId, g.name genre, b.seriesId, s.name series, b.languageId, l.name language, b.edition, b.publisherId, p.name publisher, b.pages, b.cover, b.coverTypeId, c.name coverType, b.isbn, b.releaseDate, b.purchaseDate, b.price, b.purchasePrice " +
                        "FROM Books b " +
                        "INNER JOIN Authors     a ON b.authorId = a.id " +
                        "INNER JOIN Genres      g ON b.genreId = g.id " +
                        "INNER JOIN Series      s ON b.seriesId = s.id " +
                        "INNER JOIN Languages   l ON b.languageId = l.id " +
                        "INNER JOIN Publishers  p ON b.publisherId = p.id " +
                        "INNER JOIN CoverTypes  c ON b.coverTypeId = c.id " +
                        "ORDER BY b.id";
                    } else
                    {
                        cmd.CommandText =
                        "SELECT b.id, b.title, b.authorId, a.name author, b.genreId, g.name genre, b.seriesId, s.name series, b.languageId, l.name language, b.edition, b.publisherId, p.name publisher, b.pages, b.cover, b.coverTypeId, c.name coverType, b.isbn, b.releaseDate, b.purchaseDate, b.price, b.purchasePrice " +
                        "FROM Books b " +
                        "INNER JOIN Authors     a ON b.authorId = a.id " +
                        "INNER JOIN Genres      g ON b.genreId = g.id " +
                        "INNER JOIN Series      s ON b.seriesId = s.id " +
                        "INNER JOIN Languages   l ON b.languageId = l.id " +
                        "INNER JOIN Publishers  p ON b.publisherId = p.id " +
                        "INNER JOIN CoverTypes  c ON b.coverTypeId = c.id " +
                        "WHERE b.title LIKE '%" + searchQuery + "%'" +
                        "OR a.name LIKE '%" + searchQuery + "%'" +
                        "OR s.name LIKE '%" + searchQuery + "%'" +
                        "ORDER BY b.id";
                    }

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
                        "SELECT b.id, b.title, b.authorId, a.name author, b.genreId, g.name genre, b.seriesId, s.name series, b.languageId, l.name language, b.edition, b.publisherId, p.name publisher, b.pages, b.cover, b.coverTypeId, c.name coverType, b.isbn, b.releaseDate, b.purchaseDate, b.price, b.purchasePrice " +
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

        public void UpdateBook(
            int id,
            string title,
            int authorId,
            int genreId,
            int seriesId,
            int languageId,
            string edition,
            int publisherId,
            int pages,
            string cover,
            int coverTypeId,
            string isbn,
            string releaseDate,
            string purchaseDate,
            int price,
            int purchasePrice
            )
        {
            using(var connection = new SqlConnection())
            {
                using(var cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText =
                        "UPDATE Books " +
                        "SET " +
                        "title = @title, " +
                        "authorId = @authorId, " +
                        "genreId = @genreId, " +
                        "seriesId = @seriesId, " +
                        "languageId = @languageId, " +
                        "edition = @edition, " +
                        "publisherId = @publisherId, " +
                        "pages = @pages, " +
                        "cover = @cover, " +
                        "coverTypeId = @coverTypeId, " +
                        "isbn = @isbn, " +
                        "releaseDate = @releaseDate, " +
                        "purchaseDate = @purchaseDate, " +
                        "price = @price," +
                        "purchasePrice = @purchasePrice " +
                        "WHERE id = @id";

                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("authorId", authorId);
                    cmd.Parameters.AddWithValue("genreId", genreId);
                    cmd.Parameters.AddWithValue("seriesId", seriesId);
                    cmd.Parameters.AddWithValue("languageId", languageId);
                    cmd.Parameters.AddWithValue("edition", edition);
                    cmd.Parameters.AddWithValue("publisherId", publisherId);
                    cmd.Parameters.AddWithValue("pages", pages);
                    cmd.Parameters.AddWithValue("cover", cover);
                    cmd.Parameters.AddWithValue("coverTypeId", coverTypeId);
                    cmd.Parameters.AddWithValue("isbn", isbn);
                    cmd.Parameters.AddWithValue("releaseDate", releaseDate);
                    cmd.Parameters.AddWithValue("purchaseDate", purchaseDate);
                    cmd.Parameters.AddWithValue("price", price);
                    cmd.Parameters.AddWithValue("purchasePrice", purchasePrice);
                    cmd.Parameters.AddWithValue("id", id);

                    cmd.ExecuteNonQuery();

                }
            }
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

        public List<MetaInfo> GetMeta(string type)
        {
            List<MetaInfo> _metaList = new List<MetaInfo>();

            using(SqlConnection connection = new SqlConnection())
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    cmd.Connection = connection;

                    cmd.CommandText = "SELECT * FROM " + type + " ORDER BY id";

                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _metaList.Add(new MetaInfo(
                                reader.GetInt32(reader.GetOrdinal("id")),
                                reader.GetString(reader.GetOrdinal("name"))
                                )
                            );
                        }
                    }
                }
            }

            return _metaList;
        }

    }
}