﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Common.Exceptions
{
    public class ValidateException : Exception
    {
        public string FieldName { get; }

        /// <param name="fieldName"></param>
        /// <param name="message">message optionally takes {0} where field name will be inserted</param>
        public ValidateException(string fieldName, string message)
            : this(string.Format(message, fieldName))
        {

        }

        /// <param name="message">message optionally takes {0} where field name will be inserted</param>
        public ValidateException(string message) : base(message)
        {

        }

        /// <param name="inner"></param>
        /// <param name="fieldName"></param>
        /// <param name="message">message optionally takes {0} where field name will be inserted</param>
        public ValidateException(Exception inner, string message, string fieldName)
            : base(string.Format(message, fieldName), inner)
        {
            FieldName = fieldName;
        }
    }
}
