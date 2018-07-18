using System;
using System.Collections.Generic;
using System.Text;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.ProductDetailMessage.Models
{
    public class PublicInfoModel : BaseNopModel
    {
        public string Message { get; set; }

        public bool IsEnabled { get; set; }
    }
}
