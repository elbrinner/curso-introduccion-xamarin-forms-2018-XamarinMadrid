using System;
namespace XamarinMadrid2018.Services.SpecificPlataform
{
    public interface IDialogService
    {
        void ShowAlert(string title, string message, string titleButton);
    }
}
