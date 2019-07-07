using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using UserControlLinkage.Manager;
using UserControlLinkage.ViewModels;

namespace UserControlLinkage.Models
{
    public class MenuModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        private int no;

        public MenuModel(int no)
        {
            this.no = no;
        }

        public int No
        {
            get { return this.no; }
            private set
            {
                this.no = value;
                var h = this.PropertyChanged;
                if (h != null)
                {
                    h(this, new PropertyChangedEventArgs("No"));
                }
            }
        }

        public void MenuClick()
        {
            switch(this.no)
            {
                case 1:
                    GlobalMonitoringManager.Instance.MainContents.Value = new MainContents1();
                    GlobalMonitoringManager.Instance.Title.Value = "コンテンツ１";
                    break;
                case 2:
                    GlobalMonitoringManager.Instance.MainContents.Value = new MainContents2();
                    GlobalMonitoringManager.Instance.Title.Value = "コンテンツ２";
                    break;
            }
        }

        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }
    }
}
