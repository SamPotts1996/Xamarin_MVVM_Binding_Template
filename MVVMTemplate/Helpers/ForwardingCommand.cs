using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Phylogenetic_1_0.Helpers
{
    public class ForwardingCommand : ICommand
    {
        private readonly Func<object, bool> m_fnCanExecute;
        private readonly Action<object> m_fnExecute;
        private event EventHandler m_oCanExecuteChangedEvent;
        private readonly object m_oLock = new object();

        public ForwardingCommand(Func<object, bool> fnCanExecute, Action<object> fnExecute)
        {
            if (fnExecute == null)
            {
                throw new ArgumentNullException("fnExecute");
            }

            m_fnCanExecute = fnCanExecute;
            m_fnExecute = fnExecute;
        }

        public void OnCanExecuteChanged()
        {
            var temp = m_oCanExecuteChangedEvent;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (m_fnCanExecute != null)
            {
                return m_fnCanExecute(parameter);
            }
            else
            {
                return true;
            }
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                lock (m_oLock)
                {
                    m_oCanExecuteChangedEvent += value;
                }
            }
            remove
            {
                lock (m_oLock)
                {
                    m_oCanExecuteChangedEvent -= value;
                }
            }
        }

        void ICommand.Execute(object parameter)
        {
            m_fnExecute(parameter);
        }
    }
}
