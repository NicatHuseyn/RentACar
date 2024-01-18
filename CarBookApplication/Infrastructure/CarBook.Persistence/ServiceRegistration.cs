using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Handlers.FeatureHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterface;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using CarBook.Persistence.Repositories;
using CarBook.Persistence.Repositories.BlogRepositories;
using CarBook.Persistence.Repositories.CarPricingRepositories;
using CarBook.Persistence.Repositories.CarRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CarBookContext>(option=>option.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<CarBookContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICarRepository,CarRepository>();
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<ICarPricingRepository,CarPricingRepository>();

            #region About
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();
            #endregion

            #region Banner
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();
            #endregion

            #region Brand
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();
            #endregion

            #region Car
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();
            services.AddScoped<GetLast5CarWithBrandQueryHandler>();
            #endregion

            #region Category
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
            #endregion

            #region Contact
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
            #endregion

            //#region Feature
            //services.AddScoped<GetFeatureQueryHandler>();
            //services.AddScoped<GetFeatureByIdQueryHandler>();
            //services.AddScoped<CreateFeatureCommandHandler>();
            //services.AddScoped<UpdateFeatureCommandHandler>();
            //services.AddScoped<RemoveFeatureCommand>();
            //#endregion
        }
    }
}
