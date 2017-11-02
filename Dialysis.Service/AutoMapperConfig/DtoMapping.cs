using AutoMapper;
using Dialysis.Common;

namespace Dialysis.Service.AutoMapperConfig
{
    public class DtoMapping
    {
        public static void WebApiConfigure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CommonProfile>();
                cfg.AddProfile<Profiles.WebApiProfile>();
            });
            ValidateConfigure();
        }

        public static void WebAdminConfigure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<Profiles.CommonProfile>();
                cfg.AddProfile<Profiles.WebAdminProfile>();
            });
            ValidateConfigure();
        }

        /// <summary>
        /// 验证配置
        /// </summary>
        private static void ValidateConfigure()
        {
            try
            {
                Mapper.Configuration.AssertConfigurationIsValid();
            }
            catch (AutoMapperConfigurationException ex)
            {
                LogHelper.WriteError("AutoMapper配置错误", ex);
            }
        }
    }
}
