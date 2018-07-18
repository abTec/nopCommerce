using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.ProductDetailMessage.Label")]
        public string Message { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ProductDetailMessage.Checkbox")]
        public bool IsEnabled { get; set; }
    }
}
