using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfTestApplication
{
    public class TabHeaderTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elemnt = container as FrameworkElement;
            if (item is TabItem && ((TabItem)item).IsDataTab)
                return elemnt.FindResource("TableHeaderDataTemplate") as DataTemplate;
            else
            {
                return elemnt.FindResource("MailHeaderDataTemplate") as DataTemplate;
            }
        }
    }
}
