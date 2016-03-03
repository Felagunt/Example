using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICustomerInterface;
using IValidationStratergyInterface;


namespace CustomerLibrary
{
    public abstract class CustomerBase:ICustomer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public abstract void Validate();
        public ICustomer Clone()
        {
            return (ICustomer)this.MemberwiseClone();
        }
        private IValidationStratergy<ICustomer> _ValidationType = null;
        public CustomerBase(IValidationStratergy<ICustomer> _ValidationType)
        {
            _ValidationType = _Validate;
        }
        public IValidationStratergy<ICustomer> ValidationType
        {
            get
            {
                return _ValidationType;
            }
            set
            {
                _ValidationType = value;
            }
        }
    }
}
