using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Widgets.ProductDetailMessage.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsProductDetailMessageController : BasePluginController
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;

        public WidgetsProductDetailMessageController(ILocalizationService localizationService,
            IPermissionService permissionService,
            ISettingService settingService)
        {
            _localizationService = localizationService;
            _permissionService = permissionService;
            _settingService = settingService;
        }


        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
            {
                return AccessDeniedView();
            }

            var settings = _settingService.LoadSetting<ProductDetailMessageSettings>();
            var model = new ConfigurationModel
            {
                Message = settings.Message,
                IsEnabled = settings.IsEnabled
            };

            return View("~/Plugins/Widgets.ProductDetailMessage/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            var settings = new ProductDetailMessageSettings
            {
                Message = model.Message,
                IsEnabled = model.IsEnabled
            };
            _settingService.SaveSetting(settings);
            _settingService.ClearCache();

            return Configure();
        }
    }
}
