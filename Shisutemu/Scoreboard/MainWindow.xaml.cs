using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Interactivity;
using Scoreboard.Helpers;


namespace Scoreboard
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}
}

namespace Scoreboard.Behavior
{
	public class ScaleFontBehavior : Behavior<Grid>
	{
		// MaxFontSize
		public double MaxFontSize
		{
			get
			{
				return (double)GetValue(MaxFontSizeProperty);
			}

			set
			{
				SetValue(MaxFontSizeProperty, value);
			}
		}

		public static readonly DependencyProperty MaxFontSizeProperty = DependencyProperty.Register("MaxFontSize", typeof(double), typeof(ScaleFontBehavior), new PropertyMetadata(180d));

		protected override void OnAttached()
		{
			this.AssociatedObject.SizeChanged += (s, e) => { CalculateFontSize(); };
		}

		private void CalculateFontSize()
		{
			double ResultantfontSize = this.MaxFontSize;

			List<TextBlock> Textblocks = VisualHelper.FindVisualChildren<TextBlock>(this.AssociatedObject);

			// get grid height (if limited)
			double gridHeight = double.MaxValue;
			Grid parentGrid = VisualHelper.FindUpVisualTree<Grid>(this.AssociatedObject.Parent);

			if (parentGrid != null)
			{
				RowDefinition row = parentGrid.RowDefinitions[Grid.GetRow(this.AssociatedObject)];
				gridHeight = row.Height == GridLength.Auto ? double.MaxValue : this.AssociatedObject.ActualHeight;
			}

			foreach (TextBlock Block in Textblocks)
			{
				// get desired size with fontsize = MaxFontSize
				Size desiredSize = MeasureText(Block);
				double widthMargins = Block.Margin.Left + Block.Margin.Right;
				double heightMargins = Block.Margin.Top + Block.Margin.Bottom;

				double desiredHeight = desiredSize.Height + heightMargins;
				double desiredWidth = desiredSize.Width + widthMargins;

				// adjust fontsize if text would be clipped vertically
				if (gridHeight < desiredHeight)
				{
					double factor = (desiredHeight - heightMargins) / (this.AssociatedObject.ActualHeight - heightMargins);
					ResultantfontSize = Math.Min(ResultantfontSize, MaxFontSize / factor);
				}

				// get column width (if limited)
				ColumnDefinition col = this.AssociatedObject.ColumnDefinitions[Grid.GetColumn(Block)];
				double colWidth = col.Width == GridLength.Auto ? double.MaxValue : col.ActualWidth;

				// adjust fontsize if text would be clipped horizontally
				if (colWidth < desiredWidth)
				{
					double factor = (desiredWidth - widthMargins) / (col.ActualWidth - widthMargins);
					ResultantfontSize = Math.Min(ResultantfontSize, MaxFontSize / factor);
				}
			}

			// apply fontsize (always equal fontsizes)
			foreach (TextBlock Block in Textblocks)
			{
				Block.FontSize = ResultantfontSize;
			}
		}

		// Measures text size of textblock
		private Size MeasureText(TextBlock Block)
		{
			FormattedText formattedText = new FormattedText(Block.Text, CultureInfo.CurrentUICulture,
				Block.FlowDirection,
				new Typeface(Block.FontFamily, Block.FontStyle, Block.FontWeight, Block.FontStretch),
				MaxFontSize, Brushes.Black,VisualTreeHelper.GetDpi(Block).DpiScaleY); // always uses MaxFontSize for desiredSize

			

			return new Size(formattedText.Width, formattedText.Height);
		}
	}

}
