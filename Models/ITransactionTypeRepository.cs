using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public interface ITransactionTypeRepository
    {
        IQueryable<TransactionType> _TransactionTypes { get; }

        void SaveTransactionType(TransactionType _transactionType);

        TransactionType DeleteTransactionType(int? _transactionTypeId);

    }
}
