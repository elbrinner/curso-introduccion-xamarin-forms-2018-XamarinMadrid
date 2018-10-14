using System;
using Android.App;
using Android.Widget;
using Xamarin.Forms;
using XamarinMadrid2018.Droid.SpecificPlataform;
using XamarinMadrid2018.Services.SpecificPlataform;

[assembly: Xamarin.Forms.Dependency(typeof(DialogService))]
namespace XamarinMadrid2018.Droid.SpecificPlataform
{
    public class DialogService : IDialogService
    {
        public void ShowAlert(string title, string message, string titleButton)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(Forms.Context);
            alert.SetTitle(title);
            alert.SetMessage(message);
           

            Dialog dialog = alert.Create();
            dialog.Show();

        }
    }
}
