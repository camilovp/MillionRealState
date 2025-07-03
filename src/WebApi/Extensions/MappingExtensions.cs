using Mapster;
using RealState.Api.Models;
using RealState.Application.Dtos;
using RealState.Domain.Entities;

namespace RealState.Api.Extensions
{
    public static class MappingExtensions
    {
        public static TypeAdapterConfig AddMapsterConfigs(this TypeAdapterConfig config)
        {
            //owner
            config.NewConfig<CreateOwnerRequest, CreateOwnerDto>();
            config.NewConfig<CreateOwnerDto, Owner>();
            config.NewConfig<Owner, OwnerDto>();
            config.NewConfig<OwnerDto, OwnerResponse>();
            config.NewConfig<UpdateOwnerDto, UpdateOwnerRequest>();

            //Properties
            config.NewConfig<CreatePropertyRequest, CreatePropertyDto>();
            config.NewConfig<CreatePropertyDto, Property>();
            config.NewConfig<Property, PropertyDto>();
            config.NewConfig<PropertyDto, PropertyResponse>();
            config.NewConfig<UpdatePropertyDto, UpdatePropertyRequest>();

            //propertyimages
            config.NewConfig<AddPropertyImageRequest, AddPropertyImageDto>()
                .Ignore(dest => dest.AttachedFile);
            config.NewConfig<AddPropertyImageDto, PropertyImage>();
            config.NewConfig<PropertyImage, PropertyImageDto>();
            config.NewConfig<PropertyImageDto, PropertyImageResponse>();

            //propertytraces
            config.NewConfig<AddPropertyTraceRequest, AddPropertyTraceDto>();
            config.NewConfig<AddPropertyTraceDto, PropertyTrace>();
            config.NewConfig<PropertyTrace, PropertyTraceDto>();
            config.NewConfig<PropertyTraceDto, PropertyTraceResponse>();


            return config;
        }
    }
}
