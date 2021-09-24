using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Entities
{
    public class OrganizationUnit : Base
    {
        #region Property
        /// <summary>
        /// ID đơn vị
        /// </summary>
        public string OrganizationUnitID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// ID cha
        /// </summary>
        public Guid ParentID { get; set; }

        #endregion
    }
}
