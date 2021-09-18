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
    public class SalaryCompositionTypeRepository : BaseRepository<SalaryCompositionType>, ISalaryCompositionTypeRepository
    {
        #region Constructor
        public SalaryCompositionTypeRepository(IConfiguration configuration) : base(configuration)
        {

        }
        #endregion
    }
}
