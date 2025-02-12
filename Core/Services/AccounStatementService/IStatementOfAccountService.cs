using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.StatementOfAccount
{
public interface IStatementOfAccountService
    {
        string SavetatementOfAccountService(Guid accountId, Guid customerId, DateTime dateOfTransaction, string typeOfTransaction, decimal amount, string description);
    }
}
