using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Steam.Jogos.Web.Annotations
{
    public class EmailAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            return value.ToString().EndsWith("@dev.com.br");
        }
    }
}