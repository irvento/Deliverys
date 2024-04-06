using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Deliverys.Module.BusinessObjects;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace Deliverys.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Appearance("SentAppearance", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = "IsSent = true", Context = "ListView", BackColor = "Green",
        FontColor = "White", Priority = 1)]
    public class Items : XPObject
    {
        public Items(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        DateTime estimatedTimeofArrival;
        Task task;
        int itemWeight;
        ItemTypeEnum itemType;
        string itemName;

        [Size(64)]
        public string ItemName
        {
            get => itemName;
            set => SetPropertyValue(nameof(ItemName), ref itemName, value);
        }

        public ItemTypeEnum ItemType
        {
            get => itemType;
            set => SetPropertyValue(nameof(ItemType), ref itemType, value);
        }

        public int ItemWeightbyKG
        {
            get => itemWeight;
            set => SetPropertyValue(nameof(ItemWeightbyKG), ref itemWeight, value);
        }

        bool isSent;
        DateTime? dateSent;


        public bool IsSent
        {
            get => isSent;
            set => SetPropertyValue(nameof(IsSent), ref isSent, value);
        }

        public DateTime? DateSent
        {
            get => dateSent;
            set
            {
                if (IsSent == true)
                {
                    SetPropertyValue(nameof(DateSent), ref dateSent, DateTime.Now);
                }
                else
                {
                    SetPropertyValue(nameof(DateSent), ref dateSent, value);
                }
            }
        }

        private ItemStatus itemStatus;

        [ImmediatePostData]
        public ItemStatus ItemStatus
        {
            get => itemStatus;
            set
            {
                if (IsSent == true)
                {
                    SetPropertyValue(nameof(ItemStatus), ref itemStatus, ItemStatus.Sent);
                }
                else
                {
                    SetPropertyValue(nameof(ItemStatus), ref itemStatus, ItemStatus.Pending);
                }
            }
        }


        public Task Task
        {
            get => task;
            set => SetPropertyValue(nameof(Task), ref task, value);
           
        }

        
        public DateTime EstimatedTimeofArrival
        {
            get => estimatedTimeofArrival;
            set => SetPropertyValue(nameof(EstimatedTimeofArrival), ref estimatedTimeofArrival, DateTime.Now.AddDays(7));
        }


        [Association("Sender-Items")]
        public XPCollection<Sender> Senders => GetCollection<Sender>(nameof(Senders));

        [Association("Receiver-Items")]
        public XPCollection<Receiver> Receivers => GetCollection<Receiver>(nameof(Receivers));
    }

    public enum ItemTypeEnum
    {
        Fragile,
        Perishable,
        Flammable
    }
    

    public enum ItemStatus
    {
        Pending,
        Sent
    }
}
