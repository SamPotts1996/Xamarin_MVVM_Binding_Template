using System.Collections.Generic;
using Xamarin.Forms;

namespace Phylogenetic_1_0.Helpers.EventArgsClasses
{
    class ControlChildrenEventArgs : System.EventArgs
    {
        public IList<View> ChildrenControls { get; set; }

        public ControlChildrenEventArgs(IList<View> childrenControls)
        {
            this.ChildrenControls = childrenControls;
        }
    }
}

