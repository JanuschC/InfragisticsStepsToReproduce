using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using TestPrismUnityApp.Notifications;

namespace TestPrismUnityApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public InteractionRequest<IDetailEditNotification> CustomNotificationRequest { get; set; }
        public DelegateCommand CustomNotificationCommand { get; set; }


        public MainWindowViewModel()
        {
            CustomNotificationRequest = new InteractionRequest<IDetailEditNotification>();
            CustomNotificationCommand = new DelegateCommand(RaiseCustomInteraction);

            Title = "CoboBoxEditor Tab-Forward issue";
        }

        

        private void RaiseCustomInteraction()
        {
            CustomNotificationRequest.Raise(new DetailEditNotification { Title = "Custom Notification" }, r =>
            {
                if (r.Confirmed && r.SelectedItem != null)
                    Title = $"User selected: { r.SelectedItem.Name}";
                else
                    Title = "User cancelled or didn't select an item";
            });
        }
    }
}
