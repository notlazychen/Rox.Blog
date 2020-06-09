using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Rox.Blog
{
    [DependsOn(
        typeof(AbpAccountHttpApiModule),
        typeof(AbpIdentityHttpApiModule)
        )]
    public class BlogHttpApiModule : AbpModule
    {
        
    }
}
