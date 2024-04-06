using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Deliverys.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Employee : Person
    {
        public Employee(Session session) : base(session) { }

        private string _role;
        [ImmediatePostData]
        public string Role
        {
            get => _role;
            set => SetPropertyValue(nameof(Role), ref _role, value);
        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
    }
}
