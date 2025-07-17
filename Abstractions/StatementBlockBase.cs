using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RetailCorrector.Blueprint.Abstractions
{
    public abstract class StatementBlockBase : BlockBase
    {
        private readonly static Geometry StepGeometry = Geometry.Parse("M7 6L18 15L7 24L7 6L18 15");

        protected StatementBlockBase(double width) : base(width)
        {
            var path = GenerateStepButton();
            Child.Children.Add(path);

            path = GenerateStepButton();
            Grid.SetColumn(path, 2);
            Child.Children.Add(path);
        }

        private static Path GenerateStepButton() =>
            new() { Data = StepGeometry, Stroke = Brushes.Black };
    }
}
