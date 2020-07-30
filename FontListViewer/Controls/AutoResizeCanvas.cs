using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FontListViewer.Controls
{
    /// <summary>
    /// コンテンツによっってコントロールサイズが自動調整されるクラスを定義します。
    /// </summary>
    public class AutoResizeCanvas : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            var baseSize = base.MeasureOverride(constraint);
            var children = InternalChildren.OfType<UIElement>();

            if(children.Any())
            {
                var width = children.Max(x => x.DesiredSize.Width + (double)x.GetValue(LeftProperty));
                var height = children.Max(x => x.DesiredSize.Height + (double)x.GetValue(TopProperty));

                return new Size(width, height);
            }
            else
            {
                return baseSize;
            }
        }
    }
}
