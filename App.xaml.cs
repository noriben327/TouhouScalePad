using System.Threading;
using System.Windows;

namespace TouhouScaleChanger;

public partial class App : System.Windows.Application
{
    private Mutex? _singleInstanceMutex;
    private MainWindow? _mainWindow;

    protected override void OnStartup(StartupEventArgs e)
    {
        _singleInstanceMutex = new Mutex(true, "Local\\TouhouScaleChanger.SingleInstance", out var isFirstInstance);
        if (!isFirstInstance)
        {
            System.Windows.MessageBox.Show("TouhouScaleChangerはすでに起動しています。", "TouhouScaleChanger");
            Shutdown();
            return;
        }

        base.OnStartup(e);
        _mainWindow = new MainWindow();
        MainWindow = _mainWindow;
        _mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _singleInstanceMutex?.Dispose();
        base.OnExit(e);
    }
}
