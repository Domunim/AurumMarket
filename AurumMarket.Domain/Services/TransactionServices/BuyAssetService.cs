using AurumMarket.Domain.Exceptions;
using AurumMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Services.TransactionServices
{
    public class BuyAssetService : IBuyAssetService
    {
        private readonly IDataServices<AccountModel> _accountServices;
        private readonly AssetModelingServices _assetModeling;

        public BuyAssetService(AssetModelingServices assetModelingServices, IDataServices<AccountModel> accountServices)
        {
            _assetModeling = assetModelingServices;
            _accountServices = accountServices;
        }

        public async Task<AccountModel> BuyAsset(AccountModel buyer, string symbol, int amount)
        {
            double assetPrice = Convert.ToDouble(_assetModeling.GetType().GetProperty(symbol).GetValue(_assetModeling, null));

            double transactionPrice = assetPrice / 1000 * amount;


            if (transactionPrice > buyer.Balance)
            {
                throw new InsufficientFundsException(buyer.Balance, transactionPrice);
            }

            TransactionModel transaction = new()
            {
                Account = buyer,
                Asset = new AssetModel()
                {
                    PricePerKilogram = assetPrice,
                    Symbol = symbol
                },
                Date = DateTime.Now,
                AmountInGrams = amount,
                IsPurchase = true
            };

            buyer.Transactions.Add(transaction);
            buyer.Balance -= transactionPrice;

            await _accountServices.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
