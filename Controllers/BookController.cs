using BooksWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksWebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksDbContext dbContext;

        public BookController(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;    
        }

        // 1. végpont -> javascriptből lesz hívva AJAXon kersztül
        [HttpGet("api/GetBookTitles")]
        public List<BookTitleDto> GetBookTitles()
        {
            return dbContext.Books
                .Select(book => new BookTitleDto()
                {
                    Id = book.Id,
                    Title = book.Title
                }).ToList();
        }

        // 2. végpont
        [HttpGet("api/GetBookById/{id}")]
        public Book GetBookById(int id)
        {
            return dbContext.Books.First(book => book.Id == id);
        }
    }

    // Data Transfer Object
    public class BookTitleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
