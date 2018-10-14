using System;
using UIKit;
using XamarinMadrid2018.iOS.SpecificPlataform;
using XamarinMadrid2018.Services.SpecificPlataform;

[assembly: Xamarin.Forms.Dependency(typeof(DialogService))]
namespace XamarinMadrid2018.iOS.SpecificPlataform
{
    public class DialogService : IDialogService
    {
        public void ShowAlert(string title, string message, string titleButton)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = title,
                Message = message
            };
            alert.AddButton(titleButton);
            alert.Show();
        }
    }
}
