﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp
{
    class Token
    {
        [JsonProperty("token")]
        public string AccessToken { get; set; }
    }
}
