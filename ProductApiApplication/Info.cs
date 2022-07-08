﻿using Microsoft.OpenApi.Models;

namespace ProductApiApplication
{
    internal class Info : OpenApiInfo
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}