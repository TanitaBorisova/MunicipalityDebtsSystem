using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Enums
{
    public enum DebtStatus
    {
        Unconfirmed = 1,
        Confirmed = 2,
        Finished = 3,
        Negotiated = 4,
        NegotiatedConfirmed = 5
    }
}
