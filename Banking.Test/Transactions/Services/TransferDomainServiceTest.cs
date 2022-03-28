using Banking.Domain.Accounts.Entities;
using Banking.Domain.Transactions.Services;
using System;
using Xunit;

namespace Banking.Test.Transactions.Services
{
    public class TransferDomainServiceTest
    {
        public Account GetOriginAccount()
        {
            return new Account
            {
                Number = "123456789",
                Balance = 100,
                Locked = false
            };
        }

        public Account GetDestinationAccount()
        {
            return new Account
            {
                Number = "123456788",
                Balance = 10,
                Locked = false
            };
        }


        [Fact]
        public void PerformTransferSuccess()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = GetOriginAccount();
            Account destinationAccount = GetDestinationAccount();
            decimal amount = 35;
            transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Equal(65, originAccount.Balance);
            Assert.Equal(45, destinationAccount.Balance);
        }

        [Fact]
        public void PerformTransferErrorSameAccount()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = GetOriginAccount();
            Account destinationAccount = GetOriginAccount();
            decimal amount = 35;
            Action action = () => transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void PerformTransferErrorInvalidAccounts()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = null;
            Account destinationAccount = null;
            decimal amount = 35;
            Action action = () => transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void PerformTransferErrorLockedDestinationAccount()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = GetOriginAccount();
            Account destinationAccount = GetDestinationAccount();
            decimal amount = 35;
            destinationAccount.Lock();
            Action action = () => transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void PerformTransferErrorNoMoneyOriginAccount()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = GetOriginAccount();
            Account destinationAccount = GetDestinationAccount();
            decimal amount = 150;
            Action action = () => transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void PerformTransferErrorNegativeTransference()
        {
            TransferDomainService transferDomainService = new TransferDomainService();
            Account originAccount = GetOriginAccount();
            Account destinationAccount = GetDestinationAccount();
            decimal amount = -50;
            Action action = () => transferDomainService.PerformTransfer(originAccount, destinationAccount, amount);
            Assert.Throws<ArgumentException>(action);
        }
    }
}
