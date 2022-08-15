using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static ObjectValidationLib.ObjectValidator;

namespace FinalAssignmebt
{
    class PatientDetails
    {
        public PatientDetails()
        {

        }
        [ObjectValidationLib.RequiredValidator(Error = "MRN requires value")]
        public string MRN { get; } = Guid.NewGuid().ToString();

        [ObjectValidationLib.RequiredValidator(Error = "Name requires value")]
        [ObjectValidationLib.LengthValidator(MaxLength = 15, Error = "Length of the name exceeds the limit of 15 characters")]
        public string Name { get; set; }

        [ObjectValidationLib.RangeValidatorAttribute(1, 100, Error = "Age Value Must be with in range 1-100")]
        public int Age { get; set; }
    }
}
