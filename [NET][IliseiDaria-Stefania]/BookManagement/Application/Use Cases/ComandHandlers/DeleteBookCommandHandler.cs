using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository used_repository;
        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            this.used_repository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await used_repository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} is not found!");
            }

            await used_repository.DeleteAsync(request.Id);
        }
    }
}