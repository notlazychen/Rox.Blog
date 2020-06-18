using Microsoft.Extensions.DependencyInjection;

namespace Rox.Blog.EntityFrameworkCore
{
    /// <summary>
    /// 为每个orm/数据库集成创建一个独立的集成包, 比如Entity Framework Core 和 MongoDB.
    /// 主要是仓储接口的实现
    /// </summary>
    [Dependency(
        typeof(BlogDomainModule)
        )]
    public class BlogEntityFrameworkCoreModule: ModuleBase
    {
    }
}
