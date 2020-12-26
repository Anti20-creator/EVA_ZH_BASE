using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZH.ViewModel;

namespace ZH
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Model _model;
        GameViewModel _viewModel;
        MainWindow _view;

        private void App_Startup(object sender, StartupEventArgs e)
        {
            _model = new Model();
            _viewModel = new GameViewModel(_model);

            _viewModel.StartGame += ViewModel_StartGame;

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }

        private void ViewModel_StartGame(object sender, int e)
        {
            _model.StartGame(e);
        }

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }
    }
}
