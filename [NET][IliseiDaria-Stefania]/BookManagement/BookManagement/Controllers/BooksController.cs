using Application.DTOs;
using Application.Use_Cases.ComandHandlers;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Use_Cases.QueryHandlers.GetAllBooksCommand;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetBookById), new { Id = id }, command);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BookDto>> GetBookById(Guid id)
        {
            return await mediator.Send(new GetBookByIdQuery { Id = id });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            await mediator.Send(new DeleteBookCommand { Id = id });
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateBook(Guid id, UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch.");
            }

            await mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }
    }
}
