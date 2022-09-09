using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PictureGalleryApp.Commands;
using PictureGalleryApp.Contract;
using PictureGalleryApp.Model;
using PictureGalleryApp.Server.Contract;
using PictureGalleryApp.Server.Services;
using PictureGalleryApp.ViewModel;
using PictureGalleryApp.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PictureGalleryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WindsorContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Register(Component.For<AlbumWindowViewModel>());
            container.Register(Component.For<AlbumsViewModel>());
            container.Register(Component.For<LoginViewModel>());
            container.Register(Component.For<SignUpViewModel>());
            container.Register(Component.For<MainWindowViewModel>());
            container.Register(Component.For<PictureWindowViewModel>());
            container.Register(Component.For<ProfileViewModel>());
            container.Register(Component.For<MainWindow>());
            container.Register(Component.For<AlbumWindow>());
            container.Register(Component.For<IConverter>().ImplementedBy<Converter>().LifestyleSingleton());
            container.Register(Component.For<AuthTemplate>().ImplementedBy<LoginService>().LifestyleSingleton());
            container.Register(Component.For<IAlbumAppService>().ImplementedBy<AlbumService>().LifestyleSingleton());
            container.Register(Component.For<IUserAppService>().ImplementedBy<UserService>().LifestyleSingleton());
            container.Register(Component.For<GalleryAppCommand<PictureModel>>());

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
