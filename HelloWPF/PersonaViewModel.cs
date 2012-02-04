using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace HelloWPF
{
    public class RelayCommand : ICommand
    {
        #region Fields
        
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        #endregion 

        #region Constructors

        public RelayCommand(Action<object> execute): this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }


    class PersonaViewModel : INotifyPropertyChanged
    {
        public Persona Model;

        private readonly ICommand _saludaCommand; 
        public ICommand SaludaCommand
        {
            get { return _saludaCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public PersonaViewModel()
        {
            _saludaCommand = new RelayCommand(
                o => MessageBox.Show("¡Hello, " + NombreCompleto + "!"),
                o => !string.IsNullOrEmpty(NombreCompleto.Trim()));
        }

        public string Nombre
        {
            get { return Model.Nombre; }
            set { Model.Nombre = value; NotifyChange("Nombre", "NombreCompleto"); }
        }

        public string Apellido
        {
            get { return Model.Apellido; }
            set
            {
                Model.Apellido = value;
                NotifyChange("Apellido", "NombreCompleto");
            }
        }

        public string Apellido2
        {
            get { return Model.Apellido2; }
            set
            {
                Model.Apellido2 = value;
                NotifyChange("Apellido2", "NombreCompleto");
            }
        }

        public string NombreCompleto
        {
            get { return Model.NombreCompleto; }
        }

        void NotifyChange(params string[] ids)
        {
            if (PropertyChanged != null)
    
                foreach (var id in ids)
                    PropertyChanged(this, new PropertyChangedEventArgs(id));
        }

    }
}
