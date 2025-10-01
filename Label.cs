using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Wholemy {
	public class Label : System.Windows.FrameworkElement {
		private DrawingVisual _child;
		private DrawingVisual _default;
		public DrawingVisual Child {
			get {
				return _child;
			}
			set {
				if (_child != value) {
					this.RemoveVisualChild(_child);
					_child = value;
					this.AddVisualChild(_child);
				}
			}
		}

		// Provide a required override for the VisualChildrenCount property.
		protected override int VisualChildrenCount {
			get { return _child == null ? 0 : 1; }
		}

		// Provide a required override for the GetVisualChild method.
		protected override Visual GetVisualChild(int index) {
			if (_child == null) {
				throw new ArgumentOutOfRangeException();
			}

			return _child;
		}
		private string text;
		private PathFont font;
		private double height;
		private double width;
		private double textheight;
		private double textwidth;
		public Label(string text, PathFont font, double height) {
			this.text = text;
			this.font = font;
			this.textheight = height;
			this.height = height + 20;
			var H = height + 20;
			var H2 = H / 2;
			var H25 = H2 + 10;
			var g = font.GetGeometry(H2, 10, text, height, 900, out var width);
			var bg = font.GetGeometry(H2, 10, text, height, 1900);
			this.width = width + H;
			this.textwidth = width;
			var drawingVisual = new System.Windows.Media.DrawingVisual();
			var render = drawingVisual.RenderOpen();
			var P0 = new PathSource() { Thickness = H };
			P0.AddLin11(H2, H2, width + H2, H2);
			render.DrawGeometry(Brushes.White, null, P0.Geometry);
			var P1 = new PathSource() { Thickness = H - 2 };
			P1.AddLin11(H2, H2, width + H2, H2);
			render.DrawGeometry(Brushes.Black, null, P1.Geometry);
			var P2 = new PathSource() { Thickness = H - 6 };
			P2.AddLin11(H2, H2, width + H2, H2);
			render.DrawGeometry(Brushes.DarkRed, null, P2.Geometry);
			render.DrawGeometry(Brushes.Black, null, bg);
			render.DrawGeometry(Brushes.WhiteSmoke, null, g);
			render.Close();
			Child = _default = drawingVisual;
		}
		protected override Size MeasureOverride(Size availableSize) {
			return new Size(width, height);
		}
		protected override void OnMouseDown(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseUp(e);
		}
	}
}
