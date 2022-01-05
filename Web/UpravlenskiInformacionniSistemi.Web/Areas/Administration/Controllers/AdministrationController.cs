namespace UpravlenskiInformacionniSistemi.Web.Areas.Administration.Controllers
{
    using UpravlenskiInformacionniSistemi.Common;
    using UpravlenskiInformacionniSistemi.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
