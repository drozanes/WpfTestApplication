using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace WpfTestApplication
{
    class TableFormViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private DataTable _tableData = new DataTable();
        public DataTable TableData
        {
            get
            {
                return _tableData;
            }
            set
            {
                _tableData = value;
                RaisePropertyChanged(nameof(TableData));
            }
        }

        private ICommand _browseFileCommand;
        public ICommand BrowseFileCommand
        {
            get
            {
                return _browseFileCommand ?? (_browseFileCommand = new CommandHandler(() => BrowseFile(), true));
            }
        }

        private void BrowseFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "csv files(*.csv) | *.csv";
            DataTable tempTable = new DataTable();
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    using (StreamReader stream = new StreamReader(fileDialog.FileName))
                    {
                        string[] headers = stream.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            tempTable.Columns.Add(header);
                        }
                        while (!stream.EndOfStream)
                        {
                            string[] rows = stream.ReadLine().Split(',');
                            DataRow dr = tempTable.NewRow();
                            for (int i = 0; i < headers.Length; i++)
                            {
                                dr[i] = rows[i];
                            }
                            tempTable.Rows.Add(dr);
                        }
                    }


                }
                catch (Exception ex)
                {

                }
                TableData = null;
                RaisePropertyChanged(nameof(TableData));
                TableData = tempTable;
                RaisePropertyChanged(nameof(TableData));

            }



        }
    }
}
