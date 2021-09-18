using MISA.AMI.TPLUONG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Interfaces.Repository
{
    public interface ISalaryCompositionRepository : IBaseRepository<SalaryComposition>
    {
        /// <summary>
        /// Lọc danh sách thành phần lương theo các tiêu chí và phân trang
        /// </summary>
        /// <param name="pageIndex">Index của trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi hiển thị trên 1 trang</param>
        /// <param name="statusId">Id của trạng thái cần tìm kiếm</param>
        /// <param name="organizationUnitId">Id của đơn vị cần tìm kiếm</param>
        /// <param name="keysearch">Mã, tên thành phần lương</param>
        /// <returns>Danh sách các bản ghi theo điều kiện lọc</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        object GetByPaging(int pageIndex, int pageSize, string statusId, string organizationUnitId, string keysearch);
    }
}
