using System.Collections.Generic;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Models
{
    public class ConfigurationModel : BaseNopModel, ILocalizedModel<ConfigurationModel.ConfigurationLocalizedModel>
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ProductDetailMessage.Label")]
        public string Message { get; set; }
        public bool Message_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ProductDetailMessage.Checkbox")]
        public bool IsEnabled { get; set; }
        public bool IsEnabled_OverrideForStore { get; set; }

        public class ConfigurationLocalizedModel : ILocalizedLocaleModel
        {
            public int LanguageId { get; set; }

            [NopResourceDisplayName("Plugins.Widgets.ProductDetailMessage.Label")]
            public string Message { get; set; }
        }

        public IList<ConfigurationLocalizedModel> Locales { get; set; } = new List<ConfigurationLocalizedModel>();
    }
}
