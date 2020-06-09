using Rox.Blog.MultiTenancy;
using Rox.Blog.ObjectExtending;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Rox.Blog
{
    [DependsOn(
        typeof(BlogDomainSharedModule),
        typeof(AbpIdentityDomainModule)
        )]
    public class BlogDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            BlogDomainObjectExtensions.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
