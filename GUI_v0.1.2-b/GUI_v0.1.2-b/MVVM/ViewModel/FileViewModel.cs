using GUI_v0._1._2_b.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI_v0._1._2_b.MVVM.ViewModel
{
    internal class FileViewModel : ObservableObject
    {
        // FILE CONTENT
        private string _fileContent;
        public string FileContent
        {
            get { return _fileContent; }
            set
            {
                _fileContent = value;
                OnPropertyChanged();
            }
        }

        // FILE NAME
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }

        public FileViewModel()
        {
        }
    }
}
