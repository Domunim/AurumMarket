﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class AccountModel
    {

        public int Id { get; set; }
        public UserModel AccountHolder { get; set; }
        public double Balance { get; set; }
        public IEnumerable<TransactionModel> Transactions { get; set; }

    }
}