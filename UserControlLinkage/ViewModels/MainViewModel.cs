using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlLinkage.Manager;
using UserControlLinkage.Models;

namespace UserControlLinkage.ViewModels
{
    public class MainViewModel
    {
        public ReactiveProperty<MainContents> ContentViewModel { get; private set; }

        public MainViewModel()
        {
            this.ContentViewModel  = GlobalMonitoringManager.Instance.MainContents;
        }
    }
}
