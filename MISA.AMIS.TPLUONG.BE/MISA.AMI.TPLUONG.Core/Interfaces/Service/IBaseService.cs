using MISA.AMI.TPLUONG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Interfaces.Service
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Xử lý nghiệp vụ việc thêm mới 1 đối tượng vào db
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db </returns>
        /// CreateBy:LQNhat(26/08/2021)
        ServiceResult Add(TEntity entity);

        /// <summary>
        /// Xử lý nghiệp vụ việc sửa thông tin 1 đối tượng vào db
        /// </summary>
        /// <param name="entity">Đối tượng truyền vào</param>
        /// <param name="entityId">Id của đối tượng truyền vào</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db </returns>
        /// CreateBy:LQNhat(26/08/2021)
        ServiceResult Update(TEntity entity, Guid entityId);

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">id của các đối tượng</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db</returns>
        /// CreateBy:LQNhat(26/08/2021)
        ServiceResult DeleteEntites(string entitesId);

    }
}
