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
    public class Costumer : Person
    {
        public Costumer(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        //[Association("Customer-Items")]
        //public XPCollection<Items> Item => GetCollection<Items>(nameof(Item));

        //[Association("Customer-Receivers")]
        //public XPCollection<Receiver> Receivers => GetCollection<Receiver>(nameof(Receivers));

        //[Association("Customer-Senders")]
        //public XPCollection<Sender> Senders => GetCollection<Sender>(nameof(Senders));
    }
}

