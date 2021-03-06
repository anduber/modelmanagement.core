﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class QueryResult
    {
        public object Data { get; set; }
        public int? EntityCount { get; set; }
        public bool IsSuccess { get; set; }
        public object ErrorMessage { get; set; }
    }
}
