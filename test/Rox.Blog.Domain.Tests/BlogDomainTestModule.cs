using Rox.Blog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Rox.Blog
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreTestModule)
        )]
    public class BlogDomainTestModule : AbpModule
    {

    }
}