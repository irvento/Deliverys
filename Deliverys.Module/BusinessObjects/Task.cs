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
    [Browsable(false)]
    
    public class Task : Event
    { 
        public Task(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        int priority;
        Guid guid;
DateTime estimated;

        public DateTime Estimated
        {
            get => estimated;
            set => SetPropertyValue(nameof(Estimated), ref estimated, value);
        }

        public Guid Guid
        {
            get => guid;
            set => SetPropertyValue(nameof(Guid), ref guid, value);
        }
        
        
        
    }
}