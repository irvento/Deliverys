using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace Deliverys.Module.BusinessObjects
{

    public class Person : XPObject
    {
        public Person(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        int contactNumber;
        string emailAdress;
        Address address;
        int? age;
        string lastName;
        string middleName;
        string firstName;


        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }

        [Size(32)]
        [RuleRequiredField("FirstNameIsRequired", DefaultContexts.Save, "First name must not be empty!")]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField("MiddleNameIsRequired", DefaultContexts.Save, "Middle name must not be empty!")]
        public string MiddleName
        {
            get => middleName;
            set => SetPropertyValue(nameof(MiddleName), ref middleName, value);
        }

        [Size(32)]
        [RuleRequiredField("LastNameIsRequired", DefaultContexts.Save, "Last name must not be empty!")]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }

        public int? Age
        {
            get => age;
            set => SetPropertyValue(nameof(Age), ref age, value);
        }

        public Address Address
        {
            get => address;
            set => SetPropertyValue(nameof(Address), ref address, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        [RuleRequiredField("EmailAdressIsRequired", DefaultContexts.Save, "Email name must not be empty!")]

        public string EmailAdress
         {
         	get => emailAdress;
         	set => SetPropertyValue(nameof(EmailAdress), ref emailAdress, value);
         }

        public int ContactNumber
         {
         	get => contactNumber;
         	set => SetPropertyValue(nameof(ContactNumber), ref contactNumber, value);
         }
    }
}