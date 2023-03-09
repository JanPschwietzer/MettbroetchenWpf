namespace MettbrötchenWpf
{
    public class WindowService : IWindowService
    {
        public void ShowAdminPanel()
        {
            var window = new AdminPanel();
            window.ShowDialog();
        }
    }
}