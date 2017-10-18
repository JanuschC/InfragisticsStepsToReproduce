using System;
using Infragistics.Collections;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using TestPrismUnityApp.Models;
using TestPrismUnityApp.Notifications;

namespace TestPrismUnityApp.ViewModels
{
    public class ItemSelectionViewModel : BindableBase, IInteractionRequestAware
    {
        private IDetailEditNotification _notification;
        private BusinessField _selectedItem1;
        private BusinessField _selectedItem2;
        private BusinessField _selectedItem3;

        public BusinessField SelectedItem1
        {
            get => _selectedItem1;
            set => SetProperty(ref _selectedItem1, value);
        }

        public BusinessField SelectedItem2
        {
            get => _selectedItem2;
            set => SetProperty(ref _selectedItem2, value);
        }

        public BusinessField SelectedItem3
        {
            get => _selectedItem3;
            set => SetProperty(ref _selectedItem3, value);
        }
        
        public INotification Notification
        {
            get => _notification;
            set
            {
                SetProperty(ref _notification, (IDetailEditNotification) value);
                OnNotify((IDetailEditNotification)value);
            }
        }

        private void OnNotify(IDetailEditNotification notification)
        {
            SelectedItem1 = notification.Items[0];
            SelectedItem2 = notification.Items[1];
            SelectedItem3 = notification.Items[2];
        }

        public Action FinishInteraction { get; set; }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public ItemSelectionViewModel()
        {
            SaveCommand = new DelegateCommand(OnSaveCommmand);
            CancelCommand = new DelegateCommand(OnCancelCommand);

        }

        private void OnCancelCommand()
        {
            _notification.SelectedItem = null;
            _notification.Confirmed = false;
            FinishInteraction?.Invoke();

        }

        private void OnSaveCommmand()
        {
            _notification.SelectedItem = SelectedItem1;
            _notification.Confirmed = true;
            FinishInteraction?.Invoke();
        }
    }
}
