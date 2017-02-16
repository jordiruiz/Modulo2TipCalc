using Modulo2TipCalc.Services;
using System;
using Xamarin.Forms;

namespace Modulo2TipCalc.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public MainViewModel()
        {
            TipPercent = 15;

            TipValueChanged += (sender, e) =>
            {
                TipValue = TipInfoService.CalculateTip(receiptTotal, subTotal, tipPercent);
                Total = TipInfoService.CalculateTotal(receiptTotal, tipValue);
            };
        }

        decimal receiptTotal;
        public decimal ReceiptTotal
        {
            get { return receiptTotal; }
            set
            {
                if (receiptTotal != value)
                {
                    receiptTotal = value;
                    OnPropertyChanged("ReceiptTotal");
                    OnTipValueChanged();
                }
            }
        }

        decimal subTotal;
        public decimal Subtotal
        {
            get { return subTotal; }
            set
            {
                if (subTotal != value)
                {
                    subTotal = value;
                    OnPropertyChanged("Subtotal");
                    OnTipValueChanged();
                }
            }
        }

        decimal tipPercent;
        public decimal TipPercent
        {
            get { return tipPercent; }
            set
            {
                if (value != tipPercent)
                {
                    tipPercent = value;
                    OnPropertyChanged("TipPercent");
                    OnTipValueChanged();
                }
            }
        }

        decimal total;
        public decimal Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    OnPropertyChanged("Total");                    
                }
            }
        }

        decimal tipValue;
        public decimal TipValue
        {
            get
            {
                return tipValue;
            }
            set
            {
                tipValue = value;
                OnPropertyChanged("TipValue");
            }
        }

        private void OnTipValueChanged()
        {
            var h = TipValueChanged;
            if (h != null)
                h(this, EventArgs.Empty);
        }

        public event EventHandler TipValueChanged;               
    }
}
