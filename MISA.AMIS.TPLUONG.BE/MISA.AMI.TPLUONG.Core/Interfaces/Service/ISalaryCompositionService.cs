using MISA.AMI.TPLUONG.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Interfaces.Service
{
    public interface ISalaryCompositionService : IBaseService<SalaryComposition>
    {
        /// <summary>
        /// Ngừng theo dõi nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">id của các đối tượng</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db</returns>
        /// CreateBy:LQNhat(26/08/2021)
        ServiceResult UnfollowSalaryCompositions(string entitesId);

        /// <summary>
        /// Theo dõi nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">id của các đối tượng</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db</returns>
        /// CreateBy:LQNhat(26/08/2021)
        ServiceResult FollowSalaryCompositions(string entitesId);
    }
}
