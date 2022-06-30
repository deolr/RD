using Bookstore.Models;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BookStore.Controllers
{
	/// <summary>
	/// Controller that exposes the microservices offered by the bookstore
	/// </summary>
	//[Route("api/[controller]")]
	[Route("api/books")]
	[ApiController]
	public class BookController : ControllerBase
	{
		/// <summary>
		/// An instance of the IBookRepository interface
		/// </summary>
		private readonly IBookRepository _bookRepository;


		public BookController(IBookRepository BookRepository)
		{
			_bookRepository = BookRepository;
		}

		/// <summary>
		/// Provides a list of all the Book items in the database
		/// </summary>
		/// <returns>List of Book items</returns>
		[HttpGet]
		public IActionResult Get()
		{
			var books = _bookRepository.GetBooks();
			return new OkObjectResult(books);
		}

		/// <summary>
		/// Provides details of the Book item by its id
		/// </summary>
		/// <param name="id">Id of the book</param>
		/// <returns>Book</returns>
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(int id)
		{
			var book = _bookRepository.GetBookByID(id);
			return new OkObjectResult(book);
		}

		/// <summary>
		/// Adds a new book to the database
		/// </summary>
		/// <param name="Book">Book containing details</param>
		/// <returns>Id and Book details that was just added to the database</returns>
		[HttpPost]
		public IActionResult Post([FromBody] Book Book)
		{
			using (var scope = new TransactionScope())
			{
				_bookRepository.InsertBook(Book);
				scope.Complete();
				return CreatedAtAction(nameof(Get), new { id = Book.Id }, Book);
			}
		}

		/// <summary>
		/// Update the details of a Book
		/// </summary>
		/// <param name="book">Book with new details</param>
		/// <returns>Ok if update was successful; empty result</returns>
		[HttpPut]
		public IActionResult Put([FromBody] Book book)
		{
			if (book != null)
			{
				using (var scope = new TransactionScope())
				{
					_bookRepository.UpdateBook(book);
					scope.Complete();
					return new OkResult();
				}
			}
			return new NoContentResult();
		}

		/// <summary>
		/// Removes a Book from the database
		/// </summary>
		/// <param name="id">Id of the Book to be removed</param>
		/// <returns>OKResult</returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_bookRepository.DeleteBook(id);
			return new OkResult();
		}
	}
}
