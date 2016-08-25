using System;
using MvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.Core.Models
{
    public class Customer : MvxNotifyPropertyChanged
    {
        private Guid _customerId;
        public Guid CustomerId 
        { 
            get { return _customerId; }
            set
            {
                _customerId = value;
                RaisePropertyChanged(() => CustomerId);
            }

        }

        private string _customerName;
        public string CustomerName 
        { 
            get { return _customerName; }
            set
            {
                _customerName = value;
                RaisePropertyChanged(() => CustomerName);
            }
        }

        private string _contactName;
        public string ContactName 
        {
            get { return _contactName; }
            set
            {
                _contactName = value;
                RaisePropertyChanged(() => ContactName);
            }
        }
    }
}