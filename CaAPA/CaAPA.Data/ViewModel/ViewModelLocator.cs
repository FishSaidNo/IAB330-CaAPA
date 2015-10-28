/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CaAPA.Data"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CaAPA.Data.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
		public const string TabbedHomePageKey = "TabbedHomePage";
		public const string NoteListPageKey = "NoteListPage";
		public const string RemindersHomePageKey = "RemindersPage";
		public const string PromptingHomePageKey = "PromptingHomePage";
		public const string MappingHomePageKey = "MappingHomePage";
		public const string SettingsHomePageKey = "SettingsHomePage";
		public const string SamplePagePageKey = "SamplePage";
        public const string AddActivityPageKey = "AddActivityPage";
        public const string ImagePickerPageKey = "ImagePickerPage";
        public const string AddReminderPakeKey = "AddReminderPage";
        public const string StepPageKey = "StepPage";

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			////if (ViewModelBase.IsInDesignModeStatic)
			////{
			////    // Create design time view services and models
			////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
			////}
			////else
			////{
			////    // Create run time view services and models
			////    SimpleIoc.Default.Register<IDataService, DataService>();
			////}

			SimpleIoc.Default.Register<TabbedHomeViewModel>(() =>
			{
				return new TabbedHomeViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});
			SimpleIoc.Default.Register<NoteListViewModel>(() => 
				{
					return new NoteListViewModel(
						SimpleIoc.Default.GetInstance<IMyNavigationService>()
					);
				});
			SimpleIoc.Default.Register<RemindersHomeViewModel>(() =>
			{
				return new RemindersHomeViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<PromptingHomeViewModel>(() =>
			{
				return new PromptingHomeViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<MappingHomeViewModel>(() =>
			{
				return new MappingHomeViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<SettingsHomeViewModel>(() =>
			{
				return new SettingsHomeViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<SamplePageViewModel>(() =>
			{
				return new SamplePageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

            SimpleIoc.Default.Register<AddActivityViewModel>(() =>
            {
                return new AddActivityViewModel(
                    SimpleIoc.Default.GetInstance<IMyNavigationService>()
                );
            });

            SimpleIoc.Default.Register<ImagePickerViewModel>(() =>
            {
                return new ImagePickerViewModel(
                    SimpleIoc.Default.GetInstance<IMyNavigationService>()
                );
            });

            SimpleIoc.Default.Register<StepPageViewModel>(() =>
            {
                return new StepPageViewModel(
                    SimpleIoc.Default.GetInstance<IMyNavigationService>()
                );
            });

            SimpleIoc.Default.Register<AddReminderViewModel>(() =>
            {
                return new AddReminderViewModel(
                    SimpleIoc.Default.GetInstance<IMyNavigationService>()
                );
            });
        }

		public TabbedHomeViewModel TabbedHome
		{
			get
			{
				return ServiceLocator.Current.GetInstance<TabbedHomeViewModel>();
			}
		}
		public NoteListViewModel NoteList
        {
            get
            {
				return ServiceLocator.Current.GetInstance<NoteListViewModel>();
            }
        }
		public RemindersHomeViewModel RemindersHome
		{
			get
			{
				return ServiceLocator.Current.GetInstance<RemindersHomeViewModel>();
			}
		}
		public PromptingHomeViewModel PromptingHome
		{
			get
			{
				return ServiceLocator.Current.GetInstance<PromptingHomeViewModel>();
			}
		}
		public MappingHomeViewModel MappingHome
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MappingHomeViewModel>();
			}
		}
		public SettingsHomeViewModel SettingsHome
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SettingsHomeViewModel>();
			}
		}
		public SamplePageViewModel SamplePage
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SamplePageViewModel>();
			}
		}
        public AddActivityViewModel AddActivity
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddActivityViewModel>();
            }
        }

        public ImagePickerViewModel ImagePicker
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImagePickerViewModel>();
            }
        }

        public StepPageViewModel Step
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StepPageViewModel>();
            }
        }

        public AddReminderViewModel AddReminder
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddReminderViewModel>();
            }
        }



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}