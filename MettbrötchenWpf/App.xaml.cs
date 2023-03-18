using System;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;
using Forms = System.Windows.Forms;

namespace MettbrötchenWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly Forms.NotifyIcon _notifyIcon;
        
        public App()
        {
            _notifyIcon = new Forms.NotifyIcon();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            InitNotifyIcon();
            ToastNotificationManagerCompat.OnActivated += (args) =>
            {
                ShowMainWindow();
            };
            base.OnStartup(e);
        }

        private void InitNotifyIcon()
        {
            _notifyIcon.Icon = new System.Drawing.Icon("Assets/favicon.ico");
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "GMettbrötchen";
            _notifyIcon.Click += (sender, args) => ShowContextMenu();
            _notifyIcon.DoubleClick += (sender, args) => ShowMainWindow();
        }

        private void ShowContextMenu()
        {
            _notifyIcon.ContextMenuStrip = new Forms.ContextMenuStrip();
            _notifyIcon.ContextMenuStrip.Items.Add("Zeigen").Click += (sender, args) => ShowMainWindow();
            _notifyIcon.ContextMenuStrip.Items.Add("Schließen").Click += (sender, args) => Shutdown();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _notifyIcon.Dispose();
            base.OnExit(e);
        }
        
        private void InvokeIfRequired(Action action)
        {
            if (Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Dispatcher.Invoke(action);
            }
        }
        
        private void ShowMainWindow()
        {
            InvokeIfRequired(() =>
            {
                if (MainWindow == null)
                {
                    MainWindow = new MainWindow();
                }

                if (MainWindow.Visibility == Visibility.Hidden)
                {
                    MainWindow.Visibility = Visibility.Visible;
                }

                MainWindow.Activate();
            });
        }
    }
}