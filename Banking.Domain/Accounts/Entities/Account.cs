using Banking.Domain.Accounts.Constants;
using Banking.Domain.Customers.Entities;
using Common;

namespace Banking.Domain.Accounts.Entities
{
    public class Account : Entity
    {
        public virtual string Number { get; set; }
        public virtual decimal Balance { get; set; }
        public virtual bool Locked { get; set; }
        public virtual Customer Customer { get; set; }

        public Account()
        {
        }

        public virtual void Lock() {
            if (!Locked) {
                Locked = true;
            }
        }

        public virtual void UnLock()
        {
            if (Locked) {
                Locked = false;
            }
        }

        public virtual bool HasIdentity()
        {
            return Number.Trim() != string.Empty;
        }

        public virtual void WithdrawMoney(decimal amount)
        {
            Notification notification = CanWithdrawMoney(amount);
            ThrowExceptionIfAny(notification);
            Balance = Balance - amount;
        }

        public virtual Notification CanWithdrawMoney(decimal amount)
        {
            Notification notification = new Notification();
            if (amount <= 0)
            {
                notification.AddError(AccountConstants.AmountMustBeGreaterThanZero);
            }
            if (!HasIdentity())
            {
                notification.AddError(AccountConstants.AccountHasNoIdentity);
            }
            if (Locked)
            {
                notification.AddError(AccountConstants.AccountIsLocked);
            }
            if (!CanBeWithdrawed(amount))
            {
                notification.AddError(AccountConstants.CannotWithdrawAmountIsGreaterThanBalance);
            }
            return notification;
        }

        public virtual bool CanBeWithdrawed(decimal amount)
        {
            return !Locked && Balance >= amount;
        }

        public virtual void DepositMoney(decimal amount)
        {
            Notification notification = CanDepositMoney(amount);
            ThrowExceptionIfAny(notification);
            Balance = Balance + amount;
        }

        public virtual Notification CanDepositMoney(decimal amount)
        {
            Notification notification = new Notification();
            if (amount <= 0)
            {
                notification.AddError(AccountConstants.AmountMustBeGreaterThanZero);
            }
            if (!HasIdentity())
            {
                notification.AddError(AccountConstants.AccountHasNoIdentity);
            }
            if (Locked)
            {
                notification.AddError(AccountConstants.AccountIsLocked);
            }
            return notification;
        }
    }
}
