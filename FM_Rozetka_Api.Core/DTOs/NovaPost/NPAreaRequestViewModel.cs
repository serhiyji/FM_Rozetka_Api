﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM_Rozetka_Api.Core.DTOs.NovaPost
{
    public class NPAreaProperties
    {
        public int Page { get; set; }
        public string Ref { get; set; }
    }

    public class NPAreaRequestViewModel
    {
        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty(PropertyName = "modelName")]
        public string ModelName { get; set; }

        [JsonProperty(PropertyName = "calledMethod")]
        public string CalledMethod { get; set; }

        [JsonProperty(PropertyName = "methodProperties")]
        public NPAreaProperties MethodProperties { get; set; }
    }
}
