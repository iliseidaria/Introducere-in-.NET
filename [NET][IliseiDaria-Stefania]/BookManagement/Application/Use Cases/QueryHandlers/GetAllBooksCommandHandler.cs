using Application.DTOs;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using static Application.Use_Cases.QueryHandlers.GetAllBooksCommand;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IBookRepository entire_repository;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(IBookRepository repository)
        {
            entire_repository = repository;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await entire_repository.GetAllAsync();
            return mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
