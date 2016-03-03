using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValidationStratergyInterface
{
    public interface IValidationStratergy<AnyType>
    {
        void Validate(AnyType obj);
    }
}
