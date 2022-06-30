using Bookstore.Models;
using System.Collections.Generic;

namespace Bookstore.Repository
{
    /// <summary>
    /// The interface as acts as a contract for the Repository.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Retreive all books in the repository
        /// </summary>
        /// <returns>List of Books</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Inserts a book in this context and save to the repository
        /// </summary>
        /// <param name="book">Book data to be inserted</param>
        void InsertBook(Book book);

        /// <summary>
        /// Updates an existing Book in this context and saves changes to repository
        /// </summary>
        /// <param name="book">New Book data to be updated</param>
        void UpdateBook(Book book);

        /// <summary>
        /// Deletes a Book from the repository
        /// </summary>
        /// <param name="id">Id of the book to be deleted</param>
        void DeleteBook(int id);

        /// <summary>
        ///Saves any changes made to this context
        /// </summary>
        void Save();

        /// <summary>
        /// Retrieves a Book by id
        /// </summary>
        /// <param name="id">Id of the book</param>
        /// <returns>Book data</returns>
		Book GetBookByID(int id);
	}
}
