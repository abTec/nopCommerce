using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.ProductDetailMessage.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Components
{
    [ViewComponent(Name = "WidgetsProductDetailMessage")]
    public class WidgetsProductDetailMessageViewComponent : NopViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;

        public WidgetsProductDetailMessageViewComponent(ISettingService settingService, IStoreContext storeContext)
        {
            _settingService = settingService;
            _storeContext = storeContext;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var settings = _settingService.LoadSetting<ProductDetailMessageSettings>(_storeContext.CurrentStore.Id);
            if (string.IsNullOrEmpty(settings.Message)) return Content("");

            var model = new PublicInfoModel
            {
                Message = settings.Message,
                IsEnabled = settings.IsEnabled
            };

            return View("~/Plugins/Widgets.ProductDetailMessage/Views/PublicInfo.cshtml", model);
        }
    }
}
