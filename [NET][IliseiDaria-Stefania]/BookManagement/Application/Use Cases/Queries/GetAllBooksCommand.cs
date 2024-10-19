using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetAllBooksCommand : IRequest<IEnumerable<BookDto>>
    {
        public class GetAllBooksQuery : IRequest<IEnumerable<BookDto>>
        {

        }
    }
}
