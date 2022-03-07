using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Raminagrobis.WPF.Core
{
    public class Command : ICommand
    {
        private Action _action;
        private Func<bool> _canExecute;

#pragma warning disable CS0067 // L'événement 'Command.CanExecuteChanged' n'est jamais utilisé
#pragma warning disable CS8612 // La nullabilité des types référence dans le type de 'event EventHandler Command.CanExecuteChanged' ne correspond pas au membre implémenté implicitement 'event EventHandler? ICommand.CanExecuteChanged'.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS8612 // La nullabilité des types référence dans le type de 'event EventHandler Command.CanExecuteChanged' ne correspond pas au membre implémenté implicitement 'event EventHandler? ICommand.CanExecuteChanged'.
#pragma warning restore CS0067 // L'événement 'Command.CanExecuteChanged' n'est jamais utilisé

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
#pragma warning disable CS8618 // Le événement 'CanExecuteChanged' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le événement comme nullable.
        public Command(Action action, Func<bool> canExecute)
#pragma warning restore CS8618 // Le événement 'CanExecuteChanged' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le événement comme nullable.
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action action) : this(action, () => true)
        {

        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
#pragma warning disable CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'bool Command.CanExecute(object parameter)' ne correspond pas au membre implémenté implicitement 'bool ICommand.CanExecute(object? parameter)' (probablement en raison des attributs de nullabilité).
        public bool CanExecute(object parameter)
#pragma warning restore CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'bool Command.CanExecute(object parameter)' ne correspond pas au membre implémenté implicitement 'bool ICommand.CanExecute(object? parameter)' (probablement en raison des attributs de nullabilité).
        {
            return _canExecute.Invoke();
        }

#pragma warning disable CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'void Command.Execute(object parameter)' ne correspond pas au membre implémenté implicitement 'void ICommand.Execute(object? parameter)' (probablement en raison des attributs de nullabilité).
        public void Execute(object parameter)
#pragma warning restore CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'void Command.Execute(object parameter)' ne correspond pas au membre implémenté implicitement 'void ICommand.Execute(object? parameter)' (probablement en raison des attributs de nullabilité).
        {
            _action();
        }
    }

    public class Command<T> : ICommand
    {
        private Action<T> _action;
        private Func<bool> _canExecute;

#pragma warning disable CS0067 // L'événement 'Command<T>.CanExecuteChanged' n'est jamais utilisé
#pragma warning disable CS8612 // La nullabilité des types référence dans le type de 'event EventHandler Command<T>.CanExecuteChanged' ne correspond pas au membre implémenté implicitement 'event EventHandler? ICommand.CanExecuteChanged'.
        public event EventHandler CanExecuteChanged;
#pragma warning restore CS8612 // La nullabilité des types référence dans le type de 'event EventHandler Command<T>.CanExecuteChanged' ne correspond pas au membre implémenté implicitement 'event EventHandler? ICommand.CanExecuteChanged'.
#pragma warning restore CS0067 // L'événement 'Command<T>.CanExecuteChanged' n'est jamais utilisé

        /// <summary>
        /// Creates instance of the command handler
        /// </summary>
        /// <param name="action">Action to be executed by the command</param>
        /// <param name="canExecute">A bolean property to containing current permissions to execute the command</param>
#pragma warning disable CS8618 // Le événement 'CanExecuteChanged' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le événement comme nullable.
        public Command(Action<T> action, Func<bool> canExecute)
#pragma warning restore CS8618 // Le événement 'CanExecuteChanged' non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le événement comme nullable.
        {
            _action = action;
            _canExecute = canExecute;
        }

        public Command(Action<T> action) : this(action, () => true)
        {

        }

        /// <summary>
        /// Forcess checking if execute is allowed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
#pragma warning disable CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'bool Command<T>.CanExecute(object parameter)' ne correspond pas au membre implémenté implicitement 'bool ICommand.CanExecute(object? parameter)' (probablement en raison des attributs de nullabilité).
        public bool CanExecute(object parameter)
#pragma warning restore CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'bool Command<T>.CanExecute(object parameter)' ne correspond pas au membre implémenté implicitement 'bool ICommand.CanExecute(object? parameter)' (probablement en raison des attributs de nullabilité).
        {
            return _canExecute.Invoke();
        }

#pragma warning disable CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'void Command<T>.Execute(object parameter)' ne correspond pas au membre implémenté implicitement 'void ICommand.Execute(object? parameter)' (probablement en raison des attributs de nullabilité).
        public void Execute(object parameter)
#pragma warning restore CS8767 // La nullabilité des types référence dans le type du paramètre 'parameter' de 'void Command<T>.Execute(object parameter)' ne correspond pas au membre implémenté implicitement 'void ICommand.Execute(object? parameter)' (probablement en raison des attributs de nullabilité).
        {
            _action((T)parameter);
        }
    }
}
