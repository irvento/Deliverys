using Deliverys.Module.BusinessObjects;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System;

namespace Deliverys.Module.Controllers
{
    public partial class SendItemsController : ObjectViewController<DetailView, Sender>
    {
        SimpleAction sendAction = null;

        public SendItemsController()
        {
            TargetObjectType = typeof(Items);
            TargetViewType = ViewType.Any;

            sendAction = new SimpleAction(this, "SendItemAction", PredefinedCategory.View)
            {
                Caption = "Send",
            };
            sendAction.Execute += SendAction_Execute;
        }

        private void SendAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            Items senders = null;
            if (View is ListView)
            {
                if (e.SelectedObjects.Count != 1)
                {
                    return;
                }

                senders = e.SelectedObjects[0] as Items;
            }
            if (View is DetailView)
            {
                senders = (View).CurrentObject as Items;
            }

            if (senders != null)
            {
                senders.IsSent = true;
                senders.DateSent = DateTime.Now;

                ObjectSpace.CommitChanges();
                View.Refresh();
            }
        }

        protected override void OnDeactivated()
        {
            sendAction.Execute -= SendAction_Execute;
            base.OnDeactivated();
        }
    }
}
