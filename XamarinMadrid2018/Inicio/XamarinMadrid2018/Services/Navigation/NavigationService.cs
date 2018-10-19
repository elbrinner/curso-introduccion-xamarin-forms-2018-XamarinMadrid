using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMadrid2018.Pages;
using XamarinMadrid2018.ViewModels;
using XamarinMadrid2018.ViewModels.Base;

namespace XamarinMadrid2018.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> mappings;

        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();
            CreatePageViewModelMappings();
        }

        private IDictionary<Type, Type> viewModelRouting = new Dictionary<Type, Type>()
        {
            { typeof(HomeViewModel), typeof(HomePage)},
            { typeof(DetailViewModel), typeof(DetailPage)}
        };

        private void CreatePageViewModelMappings()
        {
            mappings.Add(typeof(HomeViewModel), typeof(HomePage));
            mappings.Add(typeof(DetailViewModel), typeof(DetailPage));
        }


        public Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            return NavigateToAsync(typeof(TViewModel), parameter);
        }

        protected virtual async Task NavigateToAsync(Type viewModelType, object parameter)
        {
            Xamarin.Forms.Page page = CreateAndBindPage(viewModelType, parameter);

            if (page is HomePage)
            {
                CurrentApplication.MainPage = new NavigationPage(page);
            }
            else if (CurrentApplication.MainPage != null && CurrentApplication.MainPage.Navigation != null)
            {
                try
                {
                    await CurrentApplication.MainPage.Navigation.PushAsync(page);
                }
                catch (Exception ex)
                {
                    throw new Exception($"============ Navegation PushAsync error: " + ex.Message + "============");
                }
            }
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as BaseViewModel;

            viewModel.VMViewDidLoad(parameter);
            page.BindingContext = viewModel;
            viewModel.VMViewWillAppear(parameter);

            page.Appearing += async (object sender, EventArgs e) =>
            {
                await viewModel.VMAppearingAsync(parameter);
            };

            page.Disappearing += async (object sender, EventArgs e) =>
            {
                await viewModel.VMDisappearing();
            };

            return page;
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }

        public Task InitializeAsync()
        {
            return NavigateToAsync<HomeViewModel>();
        }
    }
}
