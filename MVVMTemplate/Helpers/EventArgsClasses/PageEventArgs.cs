using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Phylogenetic_1_0.Helpers.EventArgsClasses
{
    public class PageEventArgs : System.EventArgs
    {
        public Page Page { get; set; }

        public PageEventArgs(Page page)
        {
            this.Page = page;
        }
    }
}
