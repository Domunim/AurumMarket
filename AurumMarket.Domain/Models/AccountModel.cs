using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class AccountModel : DomainObjectModel
    {
        public UserModel AccountHolder { get; set; }
        public double Balance { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; }

    }
}
