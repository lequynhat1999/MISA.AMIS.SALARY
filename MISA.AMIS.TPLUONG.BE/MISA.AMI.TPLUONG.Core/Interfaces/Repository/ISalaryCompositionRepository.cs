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
        /// <param name="statusID">Id của trạng thái cần tìm kiếm</param>
        /// <param name="organizationUnitID">Id của đơn vị cần tìm kiếm</param>
        /// <param name="keysearch">Mã, tên thành phần lương</param>
        /// <returns>Danh sách các bản ghi theo điều kiện lọc</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        object GetByPaging(int pageIndex, int pageSize, int? statusID, string organizationUnitID, string keysearch);

        /// <summary>
        /// Ngừng theo dõi 1 đối tượng thành phần lương
        /// </summary>
        /// <param name="salaryCompositionID">ID thành phần lương</param>
        /// <returns>Số bản ghi đã thao tác</returns>
        int UnFollow(Guid salaryCompositionID);

        /// <summary>
        /// Ngừng theo dõi nhiều đối tượng trong db
        /// </summary>
        /// <param name="entitesId">mảng các đối tượng muốn xóa</param>
        /// <returns>Số bản ghi được thao tác</returns>
        int UnfollowSalaryCompositions(List<Guid> entitesId);

        /// <summary>
        /// Theo dõi 1 đối tượng thành phần lương
        /// </summary>
        /// <param name="salaryCompositionID">ID thành phần lương</param>
        /// <returns>Số bản ghi đã thao tác</returns>
        int Follow(Guid salaryCompositionID);

        /// <summary>
        /// Theo dõi nhiều đối tượng trong db
        /// </summary>
        /// <param name="entitesId">mảng các đối tượng muốn xóa</param>
        /// <returns>Số bản ghi được thao tác</returns>
        int FollowSalaryCompositions(List<Guid> entitesId);
    }
}
