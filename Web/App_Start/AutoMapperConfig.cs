namespace Web
{
    public class AutoMapperConfig
    {
        public static void ConfigureMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Domain.Models.Wishes.Wish, Web.Models.ViewModels.Wishes.WishViewModel>();
            });
        }
    }
}