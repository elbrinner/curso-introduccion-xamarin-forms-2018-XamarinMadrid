using System;
using System.Threading.Tasks;
using XamarinMadrid2018.ViewModels;
namespace XamarinMadrid2018.Services.Navigation
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;

    }
}
