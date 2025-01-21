using AutoMapper;
using Nop.Core.Infrastructure.Mapper;
using Nop.Plugin.Misc.WhatsApp.Models;


namespace Nop.Plugin.Misc.WhatsApp.Infrastructure
{
    public class MapperConfiguration : Profile, IOrderedMapperProfile
    {
        #region Properties

        public int Order => 1;

        #endregion

        #region Ctor
        public MapperConfiguration()
        {

            CreateMap<WhatsAppSettings, ConfigurationModel>()
                .ForMember(model => model.InstanceId_OverrideForStore, options => options.Ignore())
                .ForMember(model => model.Token_OverrideForStore, options => options.Ignore())
                .ForMember(model => model.ActiveStoreScopeConfiguration, options => options.Ignore());
            CreateMap<ConfigurationModel, WhatsAppSettings>();

        }
        #endregion
    }
}
