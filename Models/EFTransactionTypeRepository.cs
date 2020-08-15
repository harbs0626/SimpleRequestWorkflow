using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public class EFTransactionTypeRepository : ITransactionTypeRepository
    {
        private ApplicationDbContext _context;

        public EFTransactionTypeRepository(ApplicationDbContext _ctx)
        {
            this._context = _ctx;
        }

        public IQueryable<TransactionType> _TransactionTypes => this._context.TransactionTypes;

        public void SaveTransactionType(TransactionType _transactionType)
        {
            if (_transactionType.TransactionTypeId == 0)
            {
                this._context.TransactionTypes.Add(_transactionType);
            }
            else
            {
                TransactionType _itemEntry = this._context.TransactionTypes
                    .FirstOrDefault(item => item.TransactionTypeId == _transactionType.TransactionTypeId);

                if (_itemEntry != null)
                {
                    _itemEntry.Title = _transactionType.Title;
                    _itemEntry.Code = _transactionType.Code;
                    _itemEntry.MinimumLimit = _transactionType.MinimumLimit;
                    _itemEntry.MaximumLimit = _transactionType.MaximumLimit;

                    _itemEntry.ModifiedBy = _transactionType.ModifiedBy;
                    _itemEntry.ModifiedDateTime = _transactionType.ModifiedDateTime;
                }
            }

            this._context.SaveChanges();
        }

        public TransactionType DeleteTransactionType(int? _transactionTypeId)
        {
            TransactionType _itemEntry = this._context.TransactionTypes
                    .FirstOrDefault(item => item.TransactionTypeId == _transactionTypeId);

            if (_itemEntry != null)
            {
                this._context.TransactionTypes.Remove(_itemEntry);
                this._context.SaveChanges();
            }

            return _itemEntry;
        }
    }

}
