﻿using System;
using System.Windows.Input;

namespace AutoBet.App.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }
        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action<object> execute) : this(execute, DefaultCanExecute) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = execute;

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.canExecute = canExecute;
        }
       
        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            execute(parameter);
        }
        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
        public void Destroy()
        {
            canExecute = _ => false;
            execute = _ => { return; };
        }
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
