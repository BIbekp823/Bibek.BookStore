using Bibek.BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bibek.BookStore.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookStoreController : AbpControllerBase
{
    protected BookStoreController()
    {
        LocalizationResource = typeof(BookStoreResource);
    }
}
