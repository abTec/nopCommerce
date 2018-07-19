using Microsoft.AspNetCore.Mvc;
using Nop.Core;
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
        private readonly IStoreContext _storeContext;

        public WidgetsProductDetailMessageController(ILocalizationService localizationService,
            IPermissionService permissionService,
            ISettingService settingService, IStoreContext storeContext)
        {
            _localizationService = localizationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
            {
                return AccessDeniedView();
            }

            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<ProductDetailMessageSettings>(storeScope);
            var model = new ConfigurationModel
            {
                Message = settings.Message,
                IsEnabled = settings.IsEnabled,
                ActiveStoreScopeConfiguration = storeScope
            };
            if (storeScope > 0)
            {
                model.Message_OverrideForStore = _settingService.SettingExists(settings, x => x.Message, storeScope);
                model.IsEnabled_OverrideForStore = _settingService.SettingExists(settings, x => x.IsEnabled, storeScope);
            }

            return View("~/Plugins/Widgets.ProductDetailMessage/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public IActionResult Configure(ConfigurationModel model)
        {
            var storeScope = _storeContext.ActiveStoreScopeConfiguration;
            var settings = _settingService.LoadSetting<ProductDetailMessageSettings>(storeScope);
            settings.Message = model.Message;
            settings.IsEnabled = model.IsEnabled;

            _settingService.SaveSettingOverridablePerStore(settings, x => x.Message, model.Message_OverrideForStore, storeScope, false);
            _settingService.SaveSettingOverridablePerStore(settings, x => x.IsEnabled, model.IsEnabled_OverrideForStore, storeScope, false);

            _settingService.ClearCache();
            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));

            return Configure();
        }
    }
}
