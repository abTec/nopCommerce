using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.ProductDetailMessage.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Components
{
    [ViewComponent(Name = "WidgetsProductDetailMessage")]
    public class WidgetsProductDetailMessageViewComponent : NopViewComponent
    {
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly ILocalizationService _localizationService;

        public WidgetsProductDetailMessageViewComponent(ISettingService settingService,
            IStoreContext storeContext, IWorkContext workContext, ILocalizationService localizationService)
        {
            _settingService = settingService;
            _storeContext = storeContext;
            _workContext = workContext;
            _localizationService = localizationService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData)
        {
            var settings = _settingService.LoadSetting<ProductDetailMessageSettings>(_storeContext.CurrentStore.Id);
            if (!settings.IsEnabled || string.IsNullOrEmpty(settings.Message)) return Content("");

            var model = new PublicInfoModel
            {
                Message = _localizationService.GetLocalizedSetting(settings,
                    x => x.Message, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Widgets.ProductDetailMessage/Views/PublicInfo.cshtml", model);
        }
    }
}
