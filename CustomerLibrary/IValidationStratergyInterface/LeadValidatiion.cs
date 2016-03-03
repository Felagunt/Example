using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICustomerInterface;

namespace IValidationStratergyInterface
{
    public class LeadValidatiion:IValidationStratergy<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length == 0)
            {
                throw new Exception("Customer Name is required");
            }
            if(obj.PhoneNumber.Length==0)
            {
                throw new Exception("Phone is requered");
            }
        }
    }
}
