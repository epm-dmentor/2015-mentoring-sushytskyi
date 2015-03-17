using System.Windows;

namespace Epam.NetMentoring.CommandPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var comProvider = new CommandProvider();
            comProvider.AddCommand("FileList", new MyAppCommand(() => new FileManager().GetFiles(@"c:\")));
            comProvider.AddCommand("ProcesList", new MyAppCommand(new ProcessManager().GetListOfProcesses));
            comProvider.AddCommand("GetUrlContent", new MyAppCommand(() =>
                new RestManager().GetRestContent("http://www.thomas-bayer.com/sqlrest/CUSTOMER/3/")
            ));
            var model = new MainViewModel(comProvider);


            DataContext = model;
        }
    }
}
