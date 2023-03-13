using GUI_v0._1._2_b.Core;
using GUI_v0._1._2_b.MVVM.View;
using Microsoft.Win32;
using CliWrap;
using CliWrap.Buffered;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System;

namespace GUI_v0._1._2_b.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        // CREATE COMMAND FOR XAML MAIN OF EACH FILE
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand FileViewCommand { get; set; }

        // CREATE COMMAND FOR OPTIONS
        public RelayCommand OpenFileCommand { get; set; }
        public RelayCommand SaveAsFileCommand { get; set; }
        public RelayCommand SaveFileCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand ReplaceCommand { get; set; }
        public RelayCommand SeeSimbolCommand { get; set; }

        // CREATE THE DIFERENT VIEWS BETWEEN OTHERS
        public HomeViewModel HomeVM { get; set; }
        public FileViewModel FileVM { get; set; }

        // LOGIC FOR CHANGE VIEW
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            FileVM = new FileViewModel();
            CurrentView = HomeVM;

            // CHANGE VIEW IN THE PANEL
            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });
            FileViewCommand = new RelayCommand(o => { CurrentView = FileVM; });

            // OPTIONS
            SeeSimbolCommand = new RelayCommand(async o => { 
                string argumento = "ReadSimbol.py";
                var program = await Cli.Wrap("python")
                                        .WithValidation(CommandResultValidation.None)
                                        .WithWorkingDirectory(@"C:\Users\edwin\OneDrive\Documentos\Universidad\Dawa\GUI_v0.1.2-b\GUI_v0.1.2-b\Scripts\")
                                        .WithArguments(argumento)
                                        .ExecuteBufferedAsync();
                String data = program.StandardOutput;
                MessageBox.Show(data);
            });
            OpenFileCommand = new RelayCommand(o => {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    FileVM.FileContent = fileContent;
                    FileVM.FileName = filePath;
                    FileViewCommand.Execute(null);
                }
            });
            SaveAsFileCommand = new RelayCommand(o => {
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FileName = "mytextfile.txt"; // Establecer el nombre de archivo predeterminado

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filename = saveFileDialog.FileName;
                    string content = FileVM.FileContent;

                    File.WriteAllText(filename, content);

                    MessageBox.Show("File saved successfully.");
                }
            });
            SaveFileCommand = new RelayCommand(o =>
            {
                if (!string.IsNullOrEmpty(FileVM.FileName))
                {
                    File.WriteAllText(FileVM.FileName, FileVM.FileContent);
                    MessageBox.Show("File saved successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a file before saving.");
                }
            });
            SearchCommand = new RelayCommand(o =>
            {
                SearchView SearchWindow = new SearchView();
                SearchWindow.ShowDialog();

                string searchText = SearchWindow.Text;
                if (searchText == "The option was cancelled")
                    System.Windows.MessageBox.Show(searchText + ": Nothing to search");
                else
                {
                    string fileContent = FileVM.FileContent;
                    int index = fileContent.IndexOf(searchText);
                    if (index >= 0)
                    {
                        // Remarcar todas las coincidencias
                        string highlightedText = "";
                        int prevIndex = 0;
                        while (index >= 0)
                        {
                            // Remarcar la coincidencia
                            highlightedText += fileContent.Substring(prevIndex, index - prevIndex) +
                                "*" + searchText + "*";
                            prevIndex = index + searchText.Length;
                            index = fileContent.IndexOf(searchText, prevIndex);
                        }
                        highlightedText += fileContent.Substring(prevIndex);

                        // Asignar el resultado de la búsqueda a la propiedad FileContent de FileVM
                        FileVM.FileContent = highlightedText;

                        // Cambiar a la vista de archivo
                        FileViewCommand.Execute(null);
                    }
                    else
                        System.Windows.MessageBox.Show("No results found for \"" + searchText + "\"");
                }
            });
            ReplaceCommand = new RelayCommand(o => { System.Windows.MessageBox.Show("TO DO"); });

        }
    }
}
