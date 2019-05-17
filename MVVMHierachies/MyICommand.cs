using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMHierachies
{
    public class MyICommand : ICommand
    {
        #region Events

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public virtual event EventHandler CanExecuteChanged
        {
            // see: http://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        #endregion Events

        #region Members
        private readonly Action m_executeAction;

        private readonly Func<bool> m_canExecuteFunction;
        #endregion Members

        #region Constructors

        public MyICommand(Action executeAction)
        {
            m_canExecuteFunction = () => true;
            m_executeAction = executeAction;
        }

        public MyICommand(Func<bool> canExecuteFunction, Action executeAction)
        {
            m_executeAction = executeAction;
            m_canExecuteFunction = canExecuteFunction;
        }

        #endregion Constructors

        #region Methods
        //public void RaiseCanExecuteChanged()
        //{
        //    CanExecuteChanged(this, EventArgs.Empty);
        //}
        public bool CanExecute(object parameter)
        {
            return m_canExecuteFunction();
        }

        public void Execute(object parameter)
        {
            m_executeAction();
        }

        #endregion Methods
    }
    public class MyICommand<T>:ICommand
    {
        Action<T> _TargetExecuteMethod;
        Func<T, bool> _TargetCanExecuteMethod;
        public MyICommand(Action<T> executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }
        public MyICommand(Action<T> executeMethod,Func<T,bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
        #region ICommand Member
        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod!=null)
            {
                T tparm = (T)parameter;
                return _TargetCanExecuteMethod(tparm);
            }
            if (_TargetExecuteMethod!=null)
            {
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod!=null)
            {
                _TargetExecuteMethod((T)parameter);
            }
        }
        #endregion
    }
}
