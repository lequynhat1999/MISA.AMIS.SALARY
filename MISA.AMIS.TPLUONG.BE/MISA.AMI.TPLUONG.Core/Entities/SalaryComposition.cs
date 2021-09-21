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
        [NotMap]
        public string NatureName
        {
            get
            {
                switch (NatureID)
                {
                    case 1:
                        return "Thu nhập";
                    case 2:
                        return "Khấu trừ";
                    case 3:
                        return "Khác";
                    default:
                        return "";
                }
            }

            set { }
        }

        /// <summary>
        /// ID tính chất
        /// </summary>
        [Required]
        [Name("Tính chất")]
        public int NatureID { get; set; }
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
        ///  Tên chịu thuế
        /// </summary>
        [NotMap]
        public string TaxableName
        {
            get
            {
                switch (TaxableID)
                {
                    case 0:
                        return "Chịu thuế";
                    case 1:
                        return "Không chịu thuế";
                    default:
                        return "";
                }
            }

            set { }
        }

        /// <summary>
        /// ID chịu thuế
        /// </summary>
        public int? TaxableID { get; set; }
        /// <summary>
        /// Giảm trừ khi tính thuế
        /// </summary>
        [NotMap]
        public string ReduceName
        {
            get
            {
                switch (ReduceBoolean)
                {
                    case true:
                        return "Có";
                    case false:
                        return "Không";
                    default:
                        return "";
                }
            }

            set { }
        }

        public Boolean? ReduceBoolean { get; set; }

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
