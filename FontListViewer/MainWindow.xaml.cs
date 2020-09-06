using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FontListViewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ウィンドウの読み込みが完了したときの処理を定義します。
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FontListView.DataContext = Fonts.SystemFontFamilies;
        }

        /// <summary>
        /// 選択フォントが変更されたときの処理を定義します。
        /// </summary>
        private void FontListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var font = (FontFamily)e.AddedItems[0];

            var y = 0d;
            FontView.Children.Clear();
            CreateHeader();
            CreateParagraph(12);
            CreateParagraph(18);
            CreateParagraph(24);
            CreateParagraph(36);
            CreateParagraph(48);
            CreateParagraph(60);

            // ヘッダを描画
            void CreateHeader()
            {
                FontName.Text = $"{font}";
            }

            // 指定のフォントサイズでサンプル分を描画
            void CreateParagraph(double size)
            {
                var content = new ContentControl();
                Canvas.SetLeft(content, 0);
                Canvas.SetTop(content, y);

                var block = new TextBlock()
                {
                    FontFamily = font,
                    FontSize = size
                };
                block.Inlines.Add("abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ\n");
                block.Inlines.Add("1234567890.:,;'\"(!?)+-*/=\n");
                block.Inlines.Add("Windowsでコンピュータの世界が広がります。");

                content.Content = block;

                FontView.Children.Add(content);
                y += size * font.LineSpacing * 5d;
            }
        }
    }
}
