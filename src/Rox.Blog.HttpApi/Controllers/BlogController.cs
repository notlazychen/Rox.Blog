using Rox.Blog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Rox.Blog.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlogController : AbpController
    {
        protected BlogController()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}