using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudContactModel
{
    public class UserInfoModel : ModelBase
    {
        public string UserEmail { get; set; }
        public string UserPWD { get; set; }
        public string UserParentID { get; set; }
        public string UserTableID { get; set; }
    }
}
