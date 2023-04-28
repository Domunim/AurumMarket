using AurumMarket.Domain.Exceptions;
using AurumMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumMarket.Domain.Services.TransactionServices
{
    public class BuyAssetService : IBuyAssetService // TODO - remake interface to look like a service?
    {
        private readonly IMetalIndexServices _metalIndexServices;
        private readonly IDataServices<AccountModel> _accountServices;

        public BuyAssetService(IMetalIndexServices metalIndexServices, IDataServices<AccountModel> accountServices)
        {
            _metalIndexServices = metalIndexServices;
            _accountServices = accountServices;
        }

        public async Task<AccountModel> BuyAsset(AccountModel buyer, string symbol, int amount)
        {
            // TODO - how to pass in a created metalIndex?
            // instead of async fetching method just pass in an existing asset model of a given type

            var service = _metalIndexServices.MakeAssetFromIndex(metalIndexServices.ConvertToMetalIndex(model), AssetType.Gold);
            double assetPrice = _metalIndexServices.MakeAssetFromIndex(metalIndex, asset);
            double transactionPrice = assetPrice / 1000 * amount;


            if (assetPrice * amount > buyer.Balance)
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
