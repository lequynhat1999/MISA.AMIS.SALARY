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
    public class OrganizationUnitsController : BaseEntityController<OrganizationUnit>
    {
        #region DECLARE
        IBaseRepository<OrganizationUnit> _baseRepository;
        IBaseService<OrganizationUnit> _baseService;
        #endregion

        #region Constructor
        public OrganizationUnitsController(IBaseRepository<OrganizationUnit> baseRepository, IBaseService<OrganizationUnit> baseService) : base(baseRepository, baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion
    }
}
