﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI
{
    public class Secret
    {
        public static string Connection { get; set; } = "server=127.0.0.1;uid=root;pwd=abc123;database=movies";
    }
}
