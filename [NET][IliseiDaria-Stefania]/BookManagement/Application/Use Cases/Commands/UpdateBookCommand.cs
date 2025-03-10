﻿using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommand : IRequest<BookDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}