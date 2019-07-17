namespace SvetulkaApp.Web.Areas.Administration.Controllers
{
    using SvetulkaApp.Common;
    using SvetulkaApp.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
