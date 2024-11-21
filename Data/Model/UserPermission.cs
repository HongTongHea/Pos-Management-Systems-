using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MANAGEMENT_SYSTEM.Data.Model
{
    public class UserPermission
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        public string PermissionName { get; set; }
    }
}
