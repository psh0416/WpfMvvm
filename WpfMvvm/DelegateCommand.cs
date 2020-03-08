using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm
{
    public class DelegateCommand : ICommand
    {
        private readonly Func<object, bool> canExecute; 
        private readonly Action<object> execute;
        /// <summary> 
        /// Initializes a new instance of the DelegateCommand class. 
        /// </summary> 
        /// <param name="execute">indicate an execute function</param> 
        //public DelegateCommand(Action execute) : this(execute, null)
        //{
        //}
        /// <summary>  
        /// Initializes a new instance of the DelegateCommand class.  
        /// </summary>  
        /// <param name="execute">execute function </param>  
        /// <param name="canExecute">can execute function</param> 
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute) 
        { 
            this.execute = execute; this.canExecute = canExecute; 
        } 
        /// <summary>  
        /// can executes event handler  
        /// </summary> 
        public event EventHandler CanExecuteChanged; 
        /// <summary> 
        /// implement of icommand can execute method  
        /// </summary>  
        /// <param name="o">parameter by default of icomand interface
        /// </param>  
        /// <returns>can execute or not</returns> 
        public bool CanExecute(object o) 
        { 
            if (this.canExecute == null) 
            { 
                return true; 
            } 
            return 
                this.canExecute(o); 
        } 
        /// <summary>  
        /// implement of icommand interface execute method  
        /// </summary> 
        /// <param name="o">parameter by default of icomand interface</param> 
        public void Execute(object o) 
        {
            this.execute(o); 
        } 
        /// <summary> 
        /// raise ca excute changed when property changed 
        /// </summary> 
        public void RaiseCanExecuteChanged() 
        { 
            if (this.CanExecuteChanged != null) 
            { 
                this.CanExecuteChanged(this, EventArgs.Empty); 
            } 
        } 
    }


}
