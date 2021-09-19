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
        /// <param name="statusID">Id của trạng thái cần tìm kiếm</param>
        /// <param name="organizationUnitID">Id của đơn vị cần tìm kiếm</param>
        /// <param name="keysearch">Mã, tên thành phần lương</param>
        /// <returns>Danh sách các bản ghi theo điều kiện lọc</returns>
        /// CreateBy: LQNHAT(27/08/2021)
        public object GetByPaging(int pageIndex, int pageSize, int statusID, string organizationUnitID, string keysearch)
        {
            keysearch = keysearch == null ? string.Empty : keysearch;
            // add vào param
            var param = new DynamicParameters();
            param.Add("@keysearch", keysearch);
            param.Add("@statusId", statusID);
            param.Add("@organizationUnitId", organizationUnitID);
            param.Add("@pageIndex", pageIndex);
            param.Add("@pageSize", pageSize);
            param.Add("@totalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@totalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var employees = _dbConnection.Query<SalaryComposition>("Proc_GetSalaryCompositionsByPaging", param: param, commandType: CommandType.StoredProcedure);
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

        public int UnFollow(SalaryComposition salaryComposition, Guid salaryCompositionID)
        {
            var entityCurrent = GetById(salaryCompositionID);
            if (entityCurrent != null)
            {
                var columnsName = string.Empty;
                var param = new DynamicParameters();
                var properties = salaryComposition.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var propertyAttrNotMap = prop.GetCustomAttributes(typeof(NotMap), true);
                    if (propertyAttrNotMap.Length == 0)
                    {
                        var propName = prop.Name;
                        var propValue = prop.GetValue(salaryComposition);
                        //ngày chỉnh sửa
                        if (propName == "ModifiedDate")
                        {
                            propValue = DateTime.UtcNow;
                        }

                        if (propName == "StatusID" && (int)propValue == 0)
                        {
                            propValue = 1;
                        }
                        columnsName += $"{propName} = @{propName},";
                        param.Add($"@{propName}", propValue);
                    }
                }

                // cắt dấu phẩy cuối chuỗi
                columnsName = columnsName.Remove(columnsName.Length - 1, 1);

                // sửa dữ liệu
                var sqlQuery = $"UPDATE SalaryComposition SET {columnsName} WHERE SalaryCompositionID = '{salaryCompositionID}'";
                var result = _dbConnection.Execute(sqlQuery, param: param);
                return result;
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}

