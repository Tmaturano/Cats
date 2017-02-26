using Cats.Models;
using Cats.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cats.ViewModels
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Variables
        private bool _isBusy;
        private readonly CatRepository _repository;

        #endregion

        #region Properties

        //This property is usefull because it helps the user to realize an operation twice in a row, for example, update the data
        //multiple times.

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                Notify();

                //this is to reevaluate if the Command is avaiable to use.
                GetCatsCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Cat> Cats { get; set; }

        public Exception Error { get; set; }

        #endregion

        #region Constructor
        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            _repository = new CatRepository();

            InitializeCommands();
        }

        #endregion

        #region Commands
        public Command GetCatsCommand { get; set; }

        #endregion


        #region Methods

        //CallerMemberName here is used to avoid specifing the name of the property which will invoke this method.
        private void Notify(
        [CallerMemberName]
        string propertyName = null) =>
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propertyName)        );

        private void InitializeCommands()
        {
            GetCatsCommand = new Command(
                async () => await GetCats(),
                () => !IsBusy);
        }

        public async Task GetCats()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var items = await _repository.GetCats();

                    Cats.Clear();
                    foreach (var cat in items)
                    {
                        Cats.Add(cat);
                    }
                }
                catch (Exception ex)
                {
                    Error = ex;

                }
                finally
                {
                    IsBusy = false;

                    if (Error != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error!", Error.Message, "Ok");
                    }
                }
            }
        }

        #endregion
    }
}
