using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shipping.EFCore.WebApi.Utils
{
    public class ShippingSettings
    {
        public string ConnectionString { get; set; }
        public string ServiceApiKey { get; set; }
    }
}
