using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTestApplication
{
    class MainWindowViewModel
    {

        public ObservableCollection<TabItem> Tabs { get; set; } = new ObservableCollection<TabItem>();

        private ICommand _addDataTabCommand;
        public ICommand AddDataTabCommand
        {
            get
            {
                return _addDataTabCommand ?? (_addDataTabCommand = new CommandHandler(() => AddDataTab(), true));
            }
        }

        public void AddDataTab()
        {
            TabItem tab = new TabItem();
            tab.IsDataTab = true;
            Tabs.Add(tab);
        }

        private ICommand _addMailTabCommand;
        public ICommand AddMailTabCommand
        {
            get
            {
                return _addMailTabCommand ?? (_addDataTabCommand = new CommandHandler(() => AddMailTab(), true));
            }
        }

        public void AddMailTab()
        {
            TabItem tab = new TabItem();
            tab.IsDataTab = false;
            Tabs.Add(tab);
        }
    }

    public class TabItem
    {
        public bool IsDataTab { get; set; }
    }
}
