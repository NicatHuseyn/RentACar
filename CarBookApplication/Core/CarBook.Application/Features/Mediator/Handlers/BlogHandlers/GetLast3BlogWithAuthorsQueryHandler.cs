using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetLast3BlogWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast3BlogWithAuthorsQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast3BlogWithAuthors();
            return values.Select(x => new GetLast3BlogWithAuthorsQueryResult
            {
                Id = x.Id,
                CreatedDate = DateTime.Now,
                AuthorId = x.AuthorId,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                Title = x.Title,
                AuthorName = x.Author.Name
            }).ToList();
        }
    }
}
