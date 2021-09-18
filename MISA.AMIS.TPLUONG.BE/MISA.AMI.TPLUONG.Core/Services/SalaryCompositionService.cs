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
    }
}
