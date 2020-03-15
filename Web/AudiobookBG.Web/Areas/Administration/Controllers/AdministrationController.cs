namespace AudiobookBG.Web.Areas.Administration.Controllers
{
    using AudiobookBG.Common;
    using AudiobookBG.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
