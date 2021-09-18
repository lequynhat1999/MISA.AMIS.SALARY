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
    public class SalaryCompositionTypeService : BaseService<SalaryCompositionType>, ISalaryCompositionTypeService
    {
        #region DECLARE
        ServiceResult _serviceResult;
        ISalaryCompositionTypeRepository _salaryCompositionTypeRepository;
        #endregion

        #region Constructor
        public SalaryCompositionTypeService(ISalaryCompositionTypeRepository salaryCompositionTypeRepository) : base(salaryCompositionTypeRepository)
        {
            _serviceResult = new ServiceResult();
            _salaryCompositionTypeRepository = salaryCompositionTypeRepository;
        }
        #endregion
    }
}
