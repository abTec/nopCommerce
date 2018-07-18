using System.Collections.Generic;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.ProductDetailMessage
{
    public class ProductDetailMessagePlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ILocalizationService _localizationService;
        private readonly IWebHelper _webHelper;
        private readonly ISettingService _settingService;
        private readonly IReadOnlyDictionary<string, string> _locales = new Dictionary<string, string>
        {
            { "Plugins.Widgets.ProductDetailMessage.Description", "Task #2. Implement a new widget plugin (IWidgetPlugin). This plugin should display a message on the product details page in public store (e.g. “50% discount in December”). And this message should be editable in admin area on the widget configuration page." },
            { "Plugins.Widgets.ProductDetailMessage.Label", "Message" },
            { "Plugins.Widgets.ProductDetailMessage.Label.Hint", "Message visible on the product details page" },
            { "Plugins.Widgets.ProductDetailMessage.Checkbox", "Enabled" },
            { "Plugins.Widgets.ProductDetailMessage.Checkbox.Hint", "Determines whether the message is visible or not" },
            { "Plugins.Widgets.ProductDetailMessage.Footer", "Programmed with love in Prague @11:11pm 07/17/18. VS15, ReSharper, Coffee" }
        };

        #region Constructors

        public ProductDetailMessagePlugin(ILocalizationService localizationService, IWebHelper webHelper, ISettingService settingService)
        {
            _localizationService = localizationService;
            _webHelper = webHelper;
            _settingService = settingService;
        }

        #endregion
        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsProductDetailMessage/Configure";

        public override void Install()
        {
            var settings = new ProductDetailMessageSettings
            {
                Message = "50% discount in December",
                IsEnabled = true
            };
            _settingService.SaveSetting(settings);

            foreach (var locale in _locales)
            {
                _localizationService.AddOrUpdatePluginLocaleResource(locale.Key, locale.Value);
            }
            base.Install();
        }

        public override void Uninstall()
        {
            _settingService.DeleteSetting<ProductDetailMessageSettings>();

            foreach (var locale in _locales)
            {
                _localizationService.DeletePluginLocaleResource(locale.Key);
            }

            base.Uninstall();
        }

        public IList<string> GetWidgetZones() => new List<string> { PublicWidgetZones.ProductDetailsTop };

        public string GetWidgetViewComponentName(string widgetZone) => "ProductDetailMessage";
    }
}
