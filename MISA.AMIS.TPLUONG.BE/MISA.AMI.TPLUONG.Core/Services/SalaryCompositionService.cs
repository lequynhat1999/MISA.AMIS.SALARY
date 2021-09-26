using MISA.AMI.TPLUONG.Core.Entities;
using MISA.AMI.TPLUONG.Core.Interfaces.Repository;
using MISA.AMI.TPLUONG.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMI.TPLUONG.Core.Services
{
    public class SalaryCompositionService : BaseService<SalaryComposition>, ISalaryCompositionService
    {
        #region DECLARE
        ISalaryCompositionRepository _salaryCompositionRepository;
        ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public SalaryCompositionService(ISalaryCompositionRepository salaryCompositionRepository) : base(salaryCompositionRepository)
        {
            _serviceResult = new ServiceResult();
            _salaryCompositionRepository = salaryCompositionRepository;
        }


        #endregion

        #region Methods
        /// <summary>
        /// Ngừng theo dõi nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">Id của các đối tượng</param>
        /// <returns>ServiceResult - lưu trạng thái kết quả sau khi xử lý nghiệp vụ và thao tác với db</returns>
        /// CreateBy:LQNhat(26/08/2021)
        public ServiceResult UnfollowSalaryCompositions(string entitesId)
        {

            string[] arrId = entitesId.Split(",");
            List<Guid> idList = new List<Guid>();
            bool flag = true;
            for (int i = 0; i < arrId.Length; i++)
            {
                Guid temp = new Guid();
                if (Guid.TryParse(arrId[i], out temp))
                {
                    idList.Add(temp);
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                var result = _salaryCompositionRepository.UnfollowSalaryCompositions(idList);
                if (result == 0)
                {
                    _serviceResult.MISACode = MISAEnum.EnumServiceResult.BadRequest;
                    _serviceResult.Message = Resources.ResourceSalaryComposition.Error_ID;
                }
                else
                {
                    _serviceResult.Data = result;
                    _serviceResult.Message = Resources.ResourceSalaryComposition.Success_Unfollow_Multi;
                    _serviceResult.MISACode = MISAEnum.EnumServiceResult.Success;
                }
            }
            else
            {
                _serviceResult.MISACode = MISAEnum.EnumServiceResult.BadRequest;
                _serviceResult.Message = Resources.ResourceSalaryComposition.Error_ID;
            }
            return _serviceResult;
        }

        public ServiceResult FollowSalaryCompositions(string entitesId)
        {
            string[] arrId = entitesId.Split(",");
            List<Guid> idList = new List<Guid>();
            bool flag = true;
            for (int i = 0; i < arrId.Length; i++)
            {
                Guid temp = new Guid();
                if (Guid.TryParse(arrId[i], out temp))
                {
                    idList.Add(temp);
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                var result = _salaryCompositionRepository.FollowSalaryCompositions(idList);
                if (result == 0)
                {
                    _serviceResult.MISACode = MISAEnum.EnumServiceResult.BadRequest;
                    _serviceResult.Message = Resources.ResourceSalaryComposition.Error_ID;
                }
                else
                {
                    _serviceResult.Data = result;
                    _serviceResult.Message = Resources.ResourceSalaryComposition.Success_Follow_Multi;
                    _serviceResult.MISACode = MISAEnum.EnumServiceResult.Success;
                }
            }
            else
            {
                _serviceResult.MISACode = MISAEnum.EnumServiceResult.BadRequest;
                _serviceResult.Message = Resources.ResourceSalaryComposition.Error_ID;
            }
            return _serviceResult;
        }

        #endregion
    }
}
