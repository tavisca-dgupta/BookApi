using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiStart.Errors;

namespace WebApiStart.Model
{
    public class BookResponseModel
    {
        public int Status { get; set; }
        public List<ErrorModel> errorList { get; set; }

        public Book Book { get; set; }

        public BookResponseModel()
        {
            errorList = new List<ErrorModel>();

        }
    }
}
