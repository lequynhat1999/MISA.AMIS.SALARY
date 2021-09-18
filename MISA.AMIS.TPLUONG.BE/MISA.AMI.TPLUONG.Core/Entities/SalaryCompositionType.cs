using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Entities
{
    public class SalaryCompositionType : Base
    {
        #region Property
        /// <summary>
        /// ID loại thành phần
        /// </summary>
        public Guid SalaryCompositionTypeID { get; set; }

        /// <summary>
        /// Tên loại thành phần
        /// </summary>
        public string SalaryCompositionTypeName { get; set; }
        #endregion
    }
}
