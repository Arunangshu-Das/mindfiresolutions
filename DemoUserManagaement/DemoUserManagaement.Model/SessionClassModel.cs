using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoUserManagaement.Model
{
    public class SessionClassModel
    {
        public List<RoleModel> Roles { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
