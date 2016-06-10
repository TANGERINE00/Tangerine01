using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M1;

namespace Tangerine_Presentador.M1
{
    class PresentadorInicio
    {
        #region Variables
        private IContratoInicio _iMaster;
        private String QuerySuccess;
        private String QueryInfo;
        private String QueryError;
        #endregion

         public PresentadorInicio(IContratoInicio iMaster)
        {
           _iMaster = iMaster;
        }

    }
}
