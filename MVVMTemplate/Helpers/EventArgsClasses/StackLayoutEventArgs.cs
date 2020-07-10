using System.Collections.Generic;
using Xamarin.Forms;

namespace Phylogenetic_1_0.Helpers.EventArgsClasses
{
    class StackLayoutEventArgs : System.EventArgs
    {
        public IList<View> ChildrenControls { get; set; }

        public StackLayoutEventArgs(IList<View> childrenControls)
        {
            this.ChildrenControls = childrenControls;
        }
    }
}

