using Application.DTOs;
using Application.Use_Cases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        protected IBookRepository existent_repository;
        private readonly IMapper mapper;

        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            this.existent_repository = repository;
            this.mapper = mapper;
        }

        public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await existent_repository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} is not found!");
            }

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.PublicationDate = request.PublicationDate;

            await existent_repository.UpdateAsync(book);
            return mapper.Map<BookDto>(book);
        }
    }
}
