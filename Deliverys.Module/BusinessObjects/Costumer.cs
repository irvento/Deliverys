using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Deliverys.Module.BusinessObjects;
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
    public class Costumer : Person
    {

   

        public Costumer(Session session) : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private bool reciever;
        public bool Reciever
        {
            get => reciever;
            set => SetPropertyValue(nameof(Reciever), ref reciever, value);
        }
        private bool sender;
        public bool Sender
        {
            get => sender;
            set => SetPropertyValue(nameof(Sender), ref sender, value);
        }
    }
}

