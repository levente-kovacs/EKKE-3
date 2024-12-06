﻿using System;
using System.Windows.Input;

namespace Kliens.Core
{
    public class RelayParameterizedCommand : ICommand
    {

        private Action<object> action;


        public event EventHandler CanExecuteChanged = (sender, e) => { };


        public RelayParameterizedCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
