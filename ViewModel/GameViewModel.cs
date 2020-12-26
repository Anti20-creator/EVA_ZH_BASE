using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace ZH.ViewModel
{
    class GameViewModel : ViewModelBase
    {
        public ObservableCollection<Field> Fields { get; set; }
        Model _model;
        public DelegateCommand StartGameSmall { get; private set; }
        public DelegateCommand StartGameMedium { get; private set; }
        public DelegateCommand StartGameLarge { get; private set; }
        public int BoardSize { get { return _model.Size; } }

        public EventHandler<int> StartGame;

        public GameViewModel(Model m)
        {
            _model = m;
            Fields = new ObservableCollection<Field>();
            StartGameSmall = new DelegateCommand(
                (_) => OnStartGame(4)
            );
            StartGameMedium = new DelegateCommand(
                (_) => OnStartGame(6)
            );
            StartGameLarge = new DelegateCommand(
                (_) => OnStartGame(8)
            );
            _model.generateTable += new EventHandler<int>(GenerateTable);
        }

        private void OnStartGame(int e)
        {
            if (StartGame != null)
                StartGame(this, e);
        }

        private void GenerateTable(object sender, int e)
        {
            Fields.Clear();
            for (Int32 i = 0; i < e; i++) // inicializáljuk a mezőket
            {
                for (Int32 j = 0; j < e; j++)
                {
                    Fields.Add(new Field
                    {
                        Text = String.Empty,
                        Color = "White",
                        X = i,
                        Y = j,
                        //Number = i * _model.getSize() + j
                    });
                }
            }
            OnPropertyChanged("Fields");
        }


    }
}
