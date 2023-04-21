﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public AccountModel Account { get; set; }
        public bool Acquiring { get; set; }
        public int Amount { get; set; }

        public AssetModel Asset { get; set; }
    }
}
