using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;
using TestPrismUnityApp.Models;

namespace TestPrismUnityApp.Notifications
{
    public interface IDetailEditNotification : IConfirmation
    {
        BusinessField SelectedItem { get; set; }
        IList<BusinessField> Items { get; }
    }
}
