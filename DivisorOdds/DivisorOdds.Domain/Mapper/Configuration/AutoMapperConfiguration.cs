using AutoMapper;


namespace DivisorOdds.Domain.Mapper.Configurations
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityToResponse>();
            });
        }
    }
}
