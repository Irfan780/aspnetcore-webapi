﻿using my_books.Data.Model;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BooKVM book)
        {
            var _book = new Book()
            {
                Title=book.Title,
                Description=book.Description,
                IsRead=book.IsRead,
                DateRead=book.IsRead ? book.DateRead.Value: null,
                Rate=book.IsRead ? book.Rate.Value : null,
                Genre =book.Genre,
                CoverUrl =book.CoverUrl,
                Author=book.Author,
                DateAdded=DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return  _context.Books.ToList();
        }

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookbyId(int bookId,BooKVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            }
            return _book;
        }
        public void DelettBookById(int id)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == id);
            if (_book != null)
            {
                _context.Remove(_book);
                _context.SaveChanges();
            }
        }

    }
}
