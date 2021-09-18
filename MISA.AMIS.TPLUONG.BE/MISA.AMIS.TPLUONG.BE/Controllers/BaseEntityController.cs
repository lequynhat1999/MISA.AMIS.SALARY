using Microsoft.AspNetCore.Mvc;
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
    public class BaseEntityController<TEntity> : ControllerBase
    {
        #region DECLARE
        IBaseRepository<TEntity> _baseRepository;
        IBaseService<TEntity> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseRepository<TEntity> baseRepository, IBaseService<TEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy ra dữ liệu của toàn bộ đối tượng trong db
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy:LQNhat(26/08/2021)
        [HttpGet]
        public IActionResult GetEntites()
        {
            try
            {
                var entities = _baseRepository.Get();
                // 4. Trả về Client
                if (entities.Count() > 0)
                {
                    return StatusCode(200, entities);
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
        /// Lấy ra dữ liệu 1 đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng muốn lấy ra</param>
        /// <returns>Đối tượng lấy theo Id</returns>
        /// CreatedBy:LQNhat(26/08/2021)
        [HttpGet("{entityId}")]
        public IActionResult GetEntitesById(Guid entityId)
        {
            try
            {
                var entity = _baseRepository.GetById(entityId);
                // 4. trả về client
                if (entity != null)
                {
                    return StatusCode(200, entity);
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
        /// Thêm 1 đối tượng vào db
        /// </summary>
        /// <param name="entity">dữ liệu về đối tượngmuốn thêm</param>
        /// <returns>Số bản ghi được thêm vào trong db</returns>
        /// CreatedBy:LQNhat(26/08/2021)
        [HttpPost]
        public IActionResult InsertEntity(TEntity entity)
        {
            try
            {
                var serviceResult = _baseService.Add(entity);
                // trả kết quả về cho client
                if (serviceResult.MISACode == AMI.TPLUONG.Core.MISAEnum.EnumServiceResult.Created)
                {
                    return StatusCode(201, serviceResult.Data);
                }
                else
                {
                    return BadRequest(serviceResult);
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
        /// Sửa thông tin 1 đối tượng trong db
        /// </summary>
        /// <param name="entityId">Id của đối tượng muốn sửa</param>
        /// <param name="entity">Dữ liệu đối tượng muốn sửa</param>
        /// <returns>Số bản ghi được sửa trong db</returns>
        /// CreatedBy:LQNhat(26/08/2021)
        [HttpPut("{entityId}")]
        public IActionResult UpdateEntity(TEntity entity, Guid entityId)
        {
            try
            {
                // check Id có tồn tại k ?
                var entityCurrent = _baseRepository.GetById(entityId);
                if (entityCurrent != null)
                {
                    var serviceResult = _baseService.Update(entity, entityId);
                    // 4. trả về cho client
                    if (serviceResult.MISACode == AMI.TPLUONG.Core.MISAEnum.EnumServiceResult.Success)
                    {
                        return StatusCode(200, serviceResult.Data);
                    }
                    else
                    {
                        return BadRequest(serviceResult);
                    }
                }
                else
                {
                    var msg = new
                    {
                        devMsg = Properties.ResourceSalaryComposition.Dev_NotValid_IdSalaryCompisition,
                        userMsg = Properties.ResourceSalaryComposition.NotValid_IdSalaryComposition,
                    };
                    return StatusCode(500, msg);
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
        /// Xóa 1 đối tượng trong db
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Số dòng được xóa trong db</returns>
        /// CreatedBy:LQNhat(26/08/2021)
        [HttpDelete("{entityId}")]
        public IActionResult DeleteEntity(Guid entityId)
        {
            try
            {
                // check Id có tồn tại k ?
                var entityCurrent = _baseRepository.GetById(entityId);
                if (entityCurrent != null)
                {
                    // 4. trả kết quả về client
                    var result = _baseRepository.Delete(entityId);
                    return StatusCode(200, result);
                }
                else
                {
                    var msg = new
                    {
                        devMsg = Properties.ResourceSalaryComposition.Dev_NotValid_IdSalaryCompisition,
                        userMsg = Properties.ResourceSalaryComposition.NotValid_IdSalaryComposition,
                    };
                    return StatusCode(500, msg);
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
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="entitesId">Id các đối tượng</param>
        /// <returns></returns>
        /// CreatedBy: LQNHAT(27/08/2021)
        [HttpDelete]
        public IActionResult DeleteEntites(string entitesId)
        {
            try
            {
                var serviceResult = _baseService.DeleteEntites(entitesId);
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

