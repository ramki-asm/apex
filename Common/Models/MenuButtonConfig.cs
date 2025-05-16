using System.Windows.Input;
namespace Common.Models
{
    public class MenuButtonConfig
    {
        public string Text { get; set; }
        public string Icon { get; set; }
        public string CommandName { get; set; }
        public ICommand Command { get; set; }
        public string TagColor { get; set; }
        public bool IsVisible { get; set; }

    }
}