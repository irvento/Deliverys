using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    [Appearance("EnrolledAppearance", AppearanceItemType = "ViewItem", TargetItems = "*",
    Criteria = "IsSent = true", Context = "ListView", BackColor = "Green",
        FontColor = "White", Priority = 1)]
    public class Items : XPObject
    {
        public Items(Session session) : base(session) { }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

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

        public int ItemWeight
        {
            get => itemWeight;
            set => SetPropertyValue(nameof(ItemWeight), ref itemWeight, value);
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
            set => SetPropertyValue(nameof(DateSent), ref dateSent, value);
        }

        private ItemStatus itemStatus;

        [ImmediatePostData] 
        public ItemStatus ItemStatus
        {
            get => itemStatus;
            set 
            { 
                if(IsSent == true)
                {
                    SetPropertyValue(nameof(ItemStatus), ref itemStatus, ItemStatus.Success);
                }
                else
                {
                    SetPropertyValue(nameof(ItemStatus), ref itemStatus, ItemStatus.Pending);
                }
            }
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
        Success
    }
}
