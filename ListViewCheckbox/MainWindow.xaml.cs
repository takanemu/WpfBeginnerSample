using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListViewCheckbox
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<MyData> myData = new ObservableCollection<MyData>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = myData;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myData.Add(new MyData { IsSelected = false });
            myData.Add(new MyData { IsSelected = true });
            myData.Add(new MyData { IsSelected = false });
            myData.Add(new MyData { IsSelected = true });
            myData.Add(new MyData { IsSelected = false });
        }
    }

    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string name)
        {
            var h = PropertyChanged;
            if (h == null)
            {
                return;
            }
            h(this, new PropertyChangedEventArgs(name));
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
    }
}
