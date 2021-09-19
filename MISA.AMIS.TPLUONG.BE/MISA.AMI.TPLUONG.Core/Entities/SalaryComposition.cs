using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Entities
{
    public class SalaryComposition : Base
    {
        #region Property
        /// <summary>
        /// Id thành phần lương
        /// </summary>
        [CheckExist]
        [Name("ID thành phần lương")]
        public Guid SalaryCompositionID { get; set; }

        /// <summary>
        /// Mã thành phần lương
        /// </summary>
        [Required]
        [CheckExist]
        [Name("Mã thành phần lương")]
        public string SalaryCompositionCode { get; set; }

        /// <summary>
        /// Tên thành phần lương
        /// </summary>
        [Required]
        [Name("Tên thành phần lương")]
        public string SalaryCompositionName { get; set; }

        /// <summary>
        /// Tính chất
        /// </summary>
        [Required]
        [Name("Tính chất")]
        public string NatureName { get; set; }

        /// <summary>
        /// Id loại thành phần
        /// </summary>
        [Required]
        [Name("ID loại thành phần")]
        public Guid SalaryCompositionTypeID { get; set; }

        /// <summary>
        /// Tên loại thành phần
        /// </summary>
        [NotMap]
        public string SalaryCompositionTypeName { get; set; }

        /// <summary>
        /// Id đơn vị
        /// </summary>
        [Required]
        [Name("ID đơn vị")]
        public Guid OrganizationUnitID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        [NotMap]
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// Chịu thuế
        /// </summary>
        public string TaxableName { get; set; }

        /// <summary>
        /// Giảm trừ khi tính thuế
        /// </summary>
        public string ReduceName { get; set; }

        /// <summary>
        /// Giá trị
        /// </summary>
        public string Cost { get; set; }

        /// <summary>
        /// Định mức
        /// </summary>
        public int? Quota { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID trạng thái
        /// </summary>
        public int? StatusID { get; set; }

        /// <summary>
        /// Trạng thái
        /// </summary>
        [NotMap]
        public string StatusName
        {
            get
            {
                switch (StatusID)
                {
                    case 0:
                        return "Đang theo dõi";
                    case 1:
                        return "Ngừng theo dõi";
                    default:
                        return "";
                }
            }

            set { }
        }
        #endregion
    }
}
