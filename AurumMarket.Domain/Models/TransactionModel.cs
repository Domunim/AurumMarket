﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Models
{
    public class TransactionModel : DomainObjectModel
    {
        public AccountModel Account { get; set; }
        public bool IsPurchase { get; set; }
        public int AmountInGrams { get; set; }
        public DateTime Date { get; set; }
        public AssetModel Asset { get; set; }
    }
}
