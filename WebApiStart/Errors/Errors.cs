using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStart.Errors
{
    public class Errors
    {
        
        public ErrorModel GetError(string errorName)
        {
            switch(errorName)
            {
                case "PriceCannotBeNegetive": return new ErrorModel(102, "price Cannot be Negative");
                case "NameNotFound": return new ErrorModel(103, "Name you are Looking for is not present");
                case "InvalidName": return new ErrorModel(104, "Invalid Name: Name should not contain digits");
                case "InvalidAuthorName": return new ErrorModel(105, "Invalid Author: Author should not contain digits");
                default:return null;
            }
        }
    }
}
