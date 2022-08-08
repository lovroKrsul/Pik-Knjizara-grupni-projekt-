using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.Validation
{
    public class BoolRequired : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool) value;
        }
    }
}