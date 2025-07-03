using RealState.Application.Interfaces;
using RealState.Application.Services;
using RealState.Application.UseCases.Owners;
using RealState.Application.UseCases.Properties;
using RealState.Application.UseCases.PropertyImages;
using RealState.Application.UseCases.PropertyTraces;
using RealState.Infrastructure.FileStorage;
using RealState.Infrastructure.Mongo;
using RealState.Infrastructure.Repositories;

namespace RealState.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoSettings>(config.GetSection("MongoSettings"));
            services.AddSingleton<MongoDbContext>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IFileStorageService, FileStorage>();
            services.AddScoped<IPropertyImageRepository, PropertyImageRepository>();
            services.AddScoped<IPropertyTraceRepository, PropertyTraceRepository>();
            
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            //owner
            services.AddScoped<CreateOwnerUseCase>();
            services.AddScoped<GetAllOwnersUseCase>();
            services.AddScoped<GetOwnerByIdUseCase>();
            services.AddScoped<UpdateOwnerUseCase>();
            services.AddScoped<DeleteOwnerUseCase>();

            //properties
            services.AddScoped<CreatePropertyUseCase>();
            services.AddScoped<GetPropertyFilteredUseCase>();
            services.AddScoped<GetPropertyByIdUseCase>();
            services.AddScoped<GetPropertiesUseCase>();
            services.AddScoped<UpdatePropertyUseCase>();
            services.AddScoped<DeletePropertyUseCase>();

            //images
            services.AddScoped<AddPropertyImageUseCase>();
            services.AddScoped<ListPropertyImagesUseCase>();
            services.AddScoped<DeletePropertyImageUseCase>();
            services.AddScoped<UpdatePropertyImagesUseCases>();

            //traces
            services.AddScoped<AddPropertyTraceUseCase>();
            services.AddScoped<ListPropertyTracesUseCase>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
            services.AddScoped<OwnerService>();
            services.AddScoped<PropertyService>();
            services.AddScoped<PropertyImageService>();
            services.AddScoped<PropertyTraceService>();
            return services;
        
        }
    }
}
