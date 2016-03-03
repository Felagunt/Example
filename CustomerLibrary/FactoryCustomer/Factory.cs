using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICustomerInterface;
using CustomerLibrary;
using Microsoft.Practices.Unity;
using IValidationStratergyInterface;

namespace FactoryCustomer
{
    public static class Factory<AnyType>
    {
        static IUnityContainer container = null;
        public static AnyType Create(string Type)
        {
            if (container == null)
            {
                container = new UnityContainer();
                container.RegisterType<ICustomer, Lead>("Lead",
                    new InjectionConstructor(new LeadValidatiion()));
                container.RegisterType<ICustomer, Customer>("Customer",
                    new InjectionConstructor(new CustomerAllValidation()));
            }
            return container.Resolve<AnyType>(Type.ToString());
        }
    }
}
