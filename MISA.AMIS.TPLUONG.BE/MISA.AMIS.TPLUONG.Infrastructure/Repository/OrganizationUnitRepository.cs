using Microsoft.Extensions.Configuration;
using MISA.AMI.TPLUONG.Core.Entities;
using MISA.AMI.TPLUONG.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.TPLUONG.Infrastructure.Repository
{
    public class OrganizationUnitRepository : BaseRepository<OrganizationUnit>, IOrganizationUnitRepository
    {
        #region Constructor
        public OrganizationUnitRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}
