﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Model.Commands
{
    public class NewDraftCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object?> execute;
        private Func<object?, bool>? canExecute;

        public NewDraftCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
