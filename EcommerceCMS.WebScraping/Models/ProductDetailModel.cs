﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCMS.Models
{
    public class ProductDetailModel
    {
        [JsonProperty("productId")]
        public int ProductId { get; set; }
    }
}
