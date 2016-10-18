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
                SetProperty(ref _customerId, value);
            }

        }

        private string _customerName;
        public string CustomerName 
        { 
            get { return _customerName; }
            set
            {
                SetProperty(ref _customerName, value);
            }
        }

        private string _contactName;
        public string ContactName 
        {
            get { return _contactName; }
            set
            {
                SetProperty(ref _contactName, value);
            }
        }
    }
}