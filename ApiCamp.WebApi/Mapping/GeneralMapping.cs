using ApiCamp.WebApi.Dtos.FeatureDtos;
using ApiCamp.WebApi.Dtos.MessageDtos;
using ApiCamp.WebApi.Dtos.ProductDtos;
using ApiCamp.WebApi.Dtos.ServiceDtos;
using ApiCamp.WebApi.Dtos.TestimonialDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;

namespace ApiCamp.WebApi.Mapping

{
    public class GeneralMapping : Profile
    {


        public GeneralMapping() 
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();


            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();


            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>()
            .ForMember(dto => dto.CategoryName, opt => opt.MapFrom(product => product.Category.CategoryName))
            .ReverseMap();


            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();


            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();

        }
    }
}
