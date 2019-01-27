using System;
using NexPay.Domain.Constants;
using NexPay.Domain.Entities;
using NexPay.Domain.ValueObjects;
using Xunit;

namespace NexPay.Tests.Domain.Entities
{
    public class TransactionTests
    {
        [Fact]
        public void SetTransactionType_ValueHigherThan5000ValidTime_ShouldReturnDoc()
        {
            //Given
            var payer = new Person { Name = "test", Bank = "Itau", Agency = "3434", Account = "251" };
            var beneficiary = new Person { Name = "test2", Bank = "Caixa", Agency = "232", Account = "252" };
            var date = DateTime.Today.AddHours(13);

            var transaction = new Transaction
            {
                Value = 6000,
                Payer = payer,
                Beneficiary = beneficiary,
                CreatedDate = date
            };

            //When
            transaction.SetTransactionType();

            //Then
            Assert.Equal(TransactionTypes.Doc, transaction.TransactionType);
        }

        [Fact]
        public void SetTransactionType_SameBankValue_ShouldReturnCc()
        {
            //Given
            var payer = new Person { Name = "test", Bank = "Itau", Agency = "3434", Account = "251" };
            var beneficiary = new Person { Name = "test2", Bank = "Itau", Agency = "232", Account = "252" };
            var date = DateTime.Today.AddHours(20);

            var transaction = new Transaction
            {
                Value = 6000,
                Payer = payer,
                Beneficiary = beneficiary,
                CreatedDate = date
            };

            //When
            transaction.SetTransactionType();

            //Then
            Assert.Equal(TransactionTypes.Cc, transaction.TransactionType);
        }

        [Fact]
        public void SetTransactionType_ValueLessThan5000ValidTime_ShouldReturnTed()
        {
            //Given
            var payer = new Person { Name = "test", Bank = "Itau", Agency = "3434", Account = "251" };
            var beneficiary = new Person { Name = "test2", Bank = "Itau", Agency = "232", Account = "252" };
            var date = DateTime.Today.AddHours(13);

            var transaction = new Transaction
            {
                Value = 3000,
                Payer = payer,
                Beneficiary = beneficiary,
                CreatedDate = date
            };

            //When
            transaction.SetTransactionType();

            //Then
            Assert.Equal(TransactionTypes.Cc, transaction.TransactionType);
        }

    }
}