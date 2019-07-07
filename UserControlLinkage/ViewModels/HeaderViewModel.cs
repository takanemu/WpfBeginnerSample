using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlLinkage.Manager;

namespace UserControlLinkage.ViewModels
{
    public class HeaderViewModel
    {
        public ReactiveProperty<string> Title { get; private set; }

        public HeaderViewModel()
        {
            this.Title = GlobalMonitoringManager.Instance.Title;
        }
    }
}
