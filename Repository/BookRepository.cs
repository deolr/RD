using Microsoft.EntityFrameworkCore;
using Bookstore.DBContexts;
using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Repository
{
    /// <summary>
    /// Book repository that contains CRUD operations
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBook(int BookId)
        {
            var Book = _dbContext.Books.Find(BookId);
            _dbContext.Books.Remove(Book);
            Save();
        }

        public Book GetBookByID(int BookId)
        {
            return _dbContext.Books.Find(BookId);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void InsertBook(Book Book)
        {
            _dbContext.Add(Book);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book Book)
        {
            _dbContext.Entry(Book).State = EntityState.Modified;
            Save();
        }
    }
}