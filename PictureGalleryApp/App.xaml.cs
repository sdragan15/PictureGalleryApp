﻿using Castle.MicroKernel.Registration;
using Castle.Windsor;
using PictureGalleryApp.ViewModel;
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
            container.Register(Component.For<LoginViewModel>());
            container.Register(Component.For<SignUpViewModel>());
            container.Register(Component.For<MainWindowViewModel>());
            container.Register(Component.For<MainWindow>());

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.ShowDialog();
        }
    }
}
