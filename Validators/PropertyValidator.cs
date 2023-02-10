using Penguin.Testing.RuntimeValidation;
using Penguin.Testing.RuntimeValidation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Penguin.Cms.Modules.Testing.Validators
{
    public abstract class PropertyNameValidator : IRuntimeValidator
    {
        public virtual ValidationResults Validate(params Type[] toValidate)
        {
            if (toValidate is null)
            {
                throw new ArgumentNullException(nameof(toValidate));
            }

            ValidationResults Result = new();

            List<string> PropertyNames = new();

            foreach (Type t in toValidate)
            {
                PropertyNames.AddRange(t.GetProperties().Select(p => p.Name));
                PropertyNames.AddRange(t.GetFields().Select(p => p.Name));
            }

            PropertyNames = PropertyNames.Distinct().ToList();

            foreach (Type t in toValidate)
            {
                List<string> theseProperties = new();
                theseProperties.AddRange(t.GetProperties().Select(p => p.Name).ToList());
                theseProperties.AddRange(t.GetFields().Select(p => p.Name).ToList());

                foreach (string PropertyName in PropertyNames)
                {
                    if (!theseProperties.Contains(PropertyName))
                    {
                        Result.AddResult(new ValidationResult()
                        {
                            Success = false,
                            Checked = t,
                            Message = $"Class {t.FullName} missing property {PropertyName}"
                        });
                    }
                }
            }

            return Result;
        }

        public virtual ValidationResults Validate()
        {
            throw new NotImplementedException();
        }
    }
}