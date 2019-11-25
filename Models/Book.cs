using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InleverOpdracht1.Models
{
    public enum CoverType
    {
        Paperback,
        Hardcover,
        Unknown
    }

    public class Book
    {
        // Properties
        private int _id;
        private string _title;
        private string _author;
        private string _genre;
        private string _series;
        private string _language;
        private string _edition;
        private string _publisher;
        private int _pages;
        private string _cover; // URL
        private CoverType _coverType;
        private string _isbn;
        private string _releaseDate;
        private string _purchaseDate;
        private int _price;
        private int _purchasePrice;
        
        // Constructor
        public Book(
            int id, 
            string title, 
            string author, 
            string genre = null, 
            string series = null, 
            string language = null, 
            string edition = null, 
            string publisher = null, 
            int pages = 0, 
            string cover = null, 
            CoverType coverType = CoverType.Unknown, 
            string isbn = null, 
            string releaseDate = null, 
            string purchaseDate = null, 
            int price = 0, 
            int purchasePrice = 0)
        {
            _id = id;
            _title = title;
            _author = author;
            _genre = genre;
            _series = series;
            _language = language;
            _edition = edition;
            _publisher = publisher;
            _pages = pages;
            _cover = cover;
            _coverType = coverType;
            _isbn = isbn;
            _releaseDate = releaseDate; 
            _purchaseDate = purchaseDate; 
            _price = price;
            _purchasePrice = purchasePrice;
        }

        // Getters & Setters
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public string Genre
        {
            get => _genre;
            set => _genre = value;
        }

        public string Series
        {
            get => _series;
            set => _series = value;
        }

        public string Language
        {
            get => _language;
            set => _language = value;
        }

        public string Edition
        {
            get => _edition;
            set => _edition = value;
        }

        public string Publisher
        {
            get => _publisher;
            set => _publisher = value;
        }

        public int Pages
        {
            get => _pages;
            set => _pages = value;
        }

        public string Cover
        {
            get => _cover;
            set => _cover = value;
        }

        public CoverType CoverType
        {
            get => _coverType;
            set => _coverType = value;
        }

        public string Isbn
        {
            get => _isbn;
            set => _isbn = value;
        }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => _releaseDate = value;
        }

        public DateTime PurchaseDate
        {
            get => _purchaseDate;
            set => _purchaseDate = value;
        }

        public int Price
        {
            get => _price;
            set => _price = value;
        }

        public int PurchasePrice
        {
            get => _purchasePrice;
            set => _purchasePrice = value;
        }

        

    }
}