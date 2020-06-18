namespace Rox.Blog
{
    /// <summary>
    /// 包含应用服务接口和相关的数据传输对象(DTO).
    /// </summary>
    [Dependency(
        typeof(BlogDomainSharedModule)
        )]
    public class BlogApplicationContractsModule : ModuleBase
    {
    }
}
