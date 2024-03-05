using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace DreamsHub.Models.Infra.ControllerComponent
{
    public interface IViewRenderService
    {
        string RenderToString(Controller controller, [AspMvcPartialView] string viewName, object viewModel);
    }
}