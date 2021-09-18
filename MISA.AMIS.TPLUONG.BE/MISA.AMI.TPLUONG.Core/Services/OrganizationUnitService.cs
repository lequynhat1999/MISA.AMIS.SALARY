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
    public class OrganizationUnitService : BaseService<OrganizationUnit>, IOrganizationUnitService
    {
        #region DECLARE
        ServiceResult _serviceResult;
        IOrganizationUnitRepository _organizationUnitRepository;
        #endregion

        #region Constructor
        public OrganizationUnitService(IOrganizationUnitRepository organizationUnitRepository) : base(organizationUnitRepository)
        {
            _serviceResult = new ServiceResult();
            _organizationUnitRepository = organizationUnitRepository;
        }
        #endregion
    }
}
