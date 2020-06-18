namespace Rox.Blog
{
    /// <summary>
    /// 包含应用服务实现.
    /// </summary>
    [Dependency(
        typeof(BlogApplicationContractsModule),
        typeof(BlogDomainModule)
        )]
    public class BlogApplicationModule :ModuleBase
    {
    }
}
