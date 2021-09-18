using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.AMI.TPLUONG.Core.Entities;
using MISA.AMI.TPLUONG.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.TPLUONG.Infrastructure.Repository
{
    public class SalaryCompositionRepository : BaseRepository<SalaryComposition>, ISalaryCompositionRepository
    {
        #region DECLARE

        #endregion

        #region Constructor
        public SalaryCompositionRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy toàn bộ thành phần lương trong db
        /// </summary>
        /// <returns>Danh sách thành phần lương</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        public override IEnumerable<SalaryComposition> Get()
        {
            try
            {
                var employees = _dbConnection.Query<SalaryComposition>("Proc_GetSalaryCompositions", commandType: CommandType.StoredProcedure);
                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

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
        public object GetByPaging(int pageIndex, int pageSize, string statusId, string organizationUnitId, string keysearch)
        {
            keysearch = keysearch == null ? string.Empty : keysearch;
            // add vào param
            var param = new DynamicParameters();
            param.Add("@keysearch", keysearch);
            param.Add("@statusId", statusId);
            param.Add("@organizationUnitId", organizationUnitId);
            param.Add("@pageIndex", pageIndex);
            param.Add("@pageSize", pageSize);
            param.Add("@totalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@totalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var employees = _dbConnection.Query<SalaryComposition>("Proc_GetEmployeesByPaging", param: param, commandType: CommandType.StoredProcedure);
            // tổng số trang
            var totalPage = param.Get<int>("@totalPage");
            // tổng số bản ghi
            var toatalRecord = param.Get<int>("@totalRecord");

            var employeesFilter = new
            {
                TotalPage = totalPage,
                TotalRecord = toatalRecord,
                Data = employees,
            };
            return employeesFilter;
        }
        #endregion
    }
}

