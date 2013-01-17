using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudContactModel
{
    public class ModelBase
    {
        public string IS_DELETED { get; set; }
        public string VERSION_NO { get; set; }
        public string CREATE_BY { get; set; }
        public string CREATE_ON { get; set; }
        public string LAST_UPDATE_BY { get; set; }
        public string LAST_UPDATE_ON { get; set; }
    }
}
