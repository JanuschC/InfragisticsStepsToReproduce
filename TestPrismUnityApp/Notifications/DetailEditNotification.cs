using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;
using TestPrismUnityApp.Models;

namespace TestPrismUnityApp.Notifications
{
    public class DetailEditNotification : Confirmation, IDetailEditNotification
    {
        public IList<BusinessField> Items { get; }

        public BusinessField SelectedItem { get; set; }

        public DetailEditNotification()
        {
            Items = new List<BusinessField>();
            SelectedItem = null;

            CreateItems();
        }

        private void CreateItems()
        {
            Items.Add (new BusinessField {Id = 1, Name = "Entwicklung"});
            Items.Add(new BusinessField { Id = 1, Name = "Vertrieb" });
            Items.Add(new BusinessField { Id = 1, Name = "Buchhaltung" });
            Items.Add(new BusinessField { Id = 1, Name = "Einkauf" });
        }
    }
}
