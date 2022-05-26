using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class UserItem
    {
       
        public long Id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public EmailAddressAttribute email { get; set; }
    }
}
