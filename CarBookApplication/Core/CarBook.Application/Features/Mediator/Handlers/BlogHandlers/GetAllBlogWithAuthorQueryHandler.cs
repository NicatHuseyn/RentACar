using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery, List<GetAllBlogWithAuthorQueryResult>>
	{
		private readonly IBlogRepository _repository;

		public GetAllBlogWithAuthorQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetAllBlogsWihtAuthors();
			return values.Select(x=> new GetAllBlogWithAuthorQueryResult
			{
				Id = x.Id,
				AuthorId = x.AuthorId,
				AuthorName = x.Author.Name,
				CoverImageUrl = x.CoverImageUrl,
				Title = x.Title,
				CategoryId = x.CategoryId,
				CreatedDate = x.CreatedDate,
				Description = x.Description
			}).ToList();
		}
	}
}
