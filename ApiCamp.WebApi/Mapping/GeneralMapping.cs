using ApiCamp.WebApi.Dtos.FeatureDtos;
using ApiCamp.WebApi.Dtos.MessageDtos;
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
        }
    }
}
