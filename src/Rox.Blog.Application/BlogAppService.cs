using System;
using System.Collections.Generic;
using System.Text;
using Rox.Blog.Localization;
using Volo.Abp.Application.Services;

namespace Rox.Blog
{
    /* Inherit your application services from this class.
     */
    public abstract class BlogAppService : ApplicationService
    {
        protected BlogAppService()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}
