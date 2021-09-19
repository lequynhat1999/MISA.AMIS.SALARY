using Microsoft.AspNetCore.Mvc;
using MISA.AMI.TPLUONG.Core.Entities;
using MISA.AMI.TPLUONG.Core.Interfaces.Repository;
using MISA.AMI.TPLUONG.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.TPLUONG.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SalaryCompositionsController : BaseEntityController<SalaryComposition>
    {
        #region DECLARE
        ISalaryCompositionService _salaryCompositionService;
        ISalaryCompositionRepository _salaryCompositionRepository;
        #endregion

        #region Constructor
        public SalaryCompositionsController(ISalaryCompositionService salaryCompositionService, ISalaryCompositionRepository salaryCompositionRepository) : base(salaryCompositionRepository, salaryCompositionService)
        {
            _salaryCompositionRepository = salaryCompositionRepository;
            _salaryCompositionService = salaryCompositionService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lọc danh sách nhân viên theo các tiêu chí và phân trang
        /// </summary>
        /// <param name="pageIndex">Index của trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi hiển thị trên 1 trang</param>
        /// <param name="statusID">Id của trạng thái cần tìm kiếm</param>
        /// <param name="organizationUnitID">Id của đơn vị cần tìm kiếm</param>
        /// <param name="keysearch">Mã, tên thành phần lương</param>
        /// <returns>Danh sách các bản ghi theo điều kiện lọc</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        [HttpGet("filter")]
        public IActionResult GetSalaryCompositionsPaging(int pageIndex, int pageSize, int statusID, string organizationUnitID, string keysearch)
        {
            try
            {
                // 4. trả về cho client
                var salaryCompositionsFilter = _salaryCompositionRepository.GetByPaging(pageIndex, pageSize, statusID, organizationUnitID, keysearch);
                if (salaryCompositionsFilter != null)
                {
                    return StatusCode(200, salaryCompositionsFilter);
                }
                else
                {
                    var msg = new
                    {
                        userMsg = Properties.ResourceSalaryComposition.User_ErrorMsg_NoContent,
                    };
                    return StatusCode(204, msg);
                }
            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceSalaryComposition.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }

        /// <summary>
        /// Ngừng theo dõi thành phần lương
        /// </summary>
        /// <param name="salaryCompositionID">ID thành phần lương</param>
        /// <returns>Số bản ghi đã thao tác</returns>
        /// CreatedBy:LQNHAT(19/09/2021)
        [HttpPut("unfollow")]
        public IActionResult UnfollowSalaryComposition(Guid salaryCompositionID)
        {
            try
            {
                var result = _salaryCompositionRepository.UnFollow(salaryCompositionID);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceSalaryComposition.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }

        /// <summary>
        /// Ngừng theo dõi nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">Id các đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: LQNHAT(27/08/2021)
        [HttpPut]
        public IActionResult UnfollowSalaryCompositions(string entitesId)
        {
            try
            {
                var serviceResult = _salaryCompositionService.UnfollowSalaryCompositions(entitesId);
                if (serviceResult.MISACode == AMI.TPLUONG.Core.MISAEnum.EnumServiceResult.Success)
                {
                    return StatusCode(200, serviceResult);
                }
                else
                {
                    return BadRequest(serviceResult.Message);
                }

            }
            catch (Exception ex)
            {
                var msg = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.ResourceSalaryComposition.Exception_ErrorMsg,
                };
                return StatusCode(500, msg);
            }
        }

        #endregion
    }
}
