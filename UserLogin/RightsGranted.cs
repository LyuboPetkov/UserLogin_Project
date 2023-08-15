using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class RightsGranted
    {
        public static Dictionary<UserRoles, List<RoleRight>> UserRolesRight = new Dictionary<UserRoles, List<RoleRight>>()
        {
            {UserRoles.ADMIN, new List<RoleRight>() { RoleRight.Edit, RoleRight.View, RoleRight.Logs  }},
            {UserRoles.INSPECTOR, new List<RoleRight>() { RoleRight.View, RoleRight.Logs } },
            {UserRoles.PROFESSOR, new List<RoleRight>() { RoleRight.View }},
            {UserRoles.STUDENT, new List<RoleRight>() {} },
            {UserRoles.ANONYMOUS, new List<RoleRight>(){}}

        };

    }
}
