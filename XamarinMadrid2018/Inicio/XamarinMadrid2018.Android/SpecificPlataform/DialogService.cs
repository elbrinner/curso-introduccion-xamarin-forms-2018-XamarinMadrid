using System;
using Android.App;
using Android.Content;
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

            var alert = (new AlertDialog.Builder(Forms.Context)).Create();
            alert.SetMessage(message);
            alert.SetTitle(title);
            alert.SetButton(titleButton, handllerNotingButton);
            alert.Show();

        }

        private void handllerNotingButton(object sender, DialogClickEventArgs e)
        {

        }
    }
   
}
