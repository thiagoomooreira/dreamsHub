using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DreamsHub.Models.Infra.ControllerComponent;

public class ViewRenderService : IViewRenderService
{
    private readonly ICompositeViewEngine _compositeViewEngine;

    public ViewRenderService(ICompositeViewEngine compositeViewEngine)
    {
        this._compositeViewEngine = compositeViewEngine;
    }

    public string RenderToString(Controller controller, [AspMvcPartialView] string viewName, object viewModel)
    {
        using StringWriter writer = new StringWriter();

        PartialViewResult partialViewResult = controller.PartialView(viewName, viewModel);
        ViewEngineResult viewResult = this._compositeViewEngine.FindView(controller.ControllerContext, partialViewResult.ViewName, false);

        ViewContext viewContext = new ViewContext(
            controller.ControllerContext,
            viewResult.View,
            controller.ViewData,
            controller.TempData,
            writer,
            new HtmlHelperOptions()
        );

        viewResult.View.RenderAsync(viewContext);

        return writer.GetStringBuilder().ToString();
    }
}