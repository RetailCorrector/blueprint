using RetailCorrector.Blueprint.Abstractions;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RetailCorrector.Blueprint
{
    internal class BlockPanel : Panel
    {
        public BlockPanel()
        {

        }

        protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
        {
            //todo open menu
            base.OnMouseRightButtonUp(e);
        }
    }
}
