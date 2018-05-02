using System;
using System.Windows.Input;

/// <summary>
/// Button'a tıkladığımızda çalışacak olan metodlarımızı yazarız 
/// </summary>
#region RelayCommand
public class RelayCommand : ICommand
{
    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
    private Action methodToExecute;
    private Func<bool> canExecuteEvaluator;
    private ICommand editSave;

    public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
    {
        this.methodToExecute = methodToExecute;
        this.canExecuteEvaluator = canExecuteEvaluator;
    }
    public RelayCommand(Action methodToExecute)
        : this(methodToExecute, null)
    {
    }

    public RelayCommand(ICommand editSave)
    {
        this.editSave = editSave;
    }

    public bool CanExecute(object parameter)
    {
        if (this.canExecuteEvaluator == null)
        {
            return true;
        }
        else
        {
            bool result = this.canExecuteEvaluator.Invoke();
            return result;
        }
    }
    public void Execute(object parameter)
    {
        this.methodToExecute.Invoke();
    }

}
#endregion