using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHierachies.Model
{
    class SimpleEditableCustomer:ValidatableBindableBase
    {
        private Guid _id;
        public Guid ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }

        }
        private string _firstName;
        //[Required];
        public string FristName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }

        }
        public string _lastName;
        //[Required]
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        private string _email;
        //[Required]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        private string _phone;
        //[Required]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }
    }
}
