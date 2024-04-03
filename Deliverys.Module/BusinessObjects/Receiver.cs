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
    [DefaultClassOptions]
    public class Receiver : Costumer
    {
        public Receiver(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Association("Receiver-Items")]
        public XPCollection<Items> Item => GetCollection<Items>(nameof(Item));
    }
}