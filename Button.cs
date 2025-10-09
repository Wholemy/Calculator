using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Wholemy {
	[DefaultEvent("Click")]
	public class Button : System.Windows.FrameworkElement {
		public static readonly RoutedEvent ClickEvent=EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Button));
		public event RoutedEventHandler Click {
			add {
				AddHandler(ClickEvent, value);
			}
			remove {
				RemoveHandler(ClickEvent, value);
			}
		}
		public static readonly RoutedEvent EnterEvent = EventManager.RegisterRoutedEvent("Enter", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Button));
		public event RoutedEventHandler Enter {
			add {
				AddHandler(EnterEvent, value);
			}
			remove {
				RemoveHandler(EnterEvent, value);
			}
		}
		private DrawingVisual _child;
		private DrawingVisual _default;
		private DrawingVisual _enter;
		private DrawingVisual _down;
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
		public string Text {
			get { return text; }
		}
		private PathFont font;
		private double height;
		private double width;
		private double textheight;
		private double textwidth;
		public Button(string text, PathFont font, double height) {
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
		private bool entered;
		protected override void OnMouseEnter(MouseEventArgs e) {
			if (!entered) {
				entered = true;
				if (_enter == null) {
					var H = textheight + 20;
					var H2 = H / 2;
					var H25 = H2 + 10;
					var g = font.GetGeometry(H2, 10, text, textheight, 600);
					var bg = font.GetGeometry(H2, 10, text, textheight, 1600);
					var drawingVisual = new System.Windows.Media.DrawingVisual();
					var render = drawingVisual.RenderOpen();
					var P0 = new PathSource() { Thickness = H };
					P0.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.Yellow, null, P0.Geometry);
					var P1 = new PathSource() { Thickness = H - 2 };
					P1.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.Black, null, P1.Geometry);
					var P2 = new PathSource() { Thickness = H - 6 };
					P2.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.DarkRed, null, P2.Geometry);
					render.DrawGeometry(Brushes.Black, null, bg);
					render.DrawGeometry(Brushes.Yellow, null, g);
					render.Close();
					_enter = drawingVisual;
				}
				Child = _enter;
				e.Handled = true;
				RoutedEventArgs ee = new RoutedEventArgs(EnterEvent, this);
				RaiseEvent(ee);
			}
			base.OnMouseEnter(e);
		}
		protected override void OnMouseLeave(MouseEventArgs e) {
			if (entered) {
				entered = false;
				downed = false;
				Child = _default;
				e.Handled = true;
			}
			base.OnMouseLeave(e);
		}
		private bool downed;
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e) {
			if (entered && !downed) {
				downed = true;
				if (_down == null) {
					var H = textheight + 20;
					var H2 = H / 2;
					var H25 = H2 + 10;
					var g = font.GetGeometry(H2, 10, text, textheight, 300);
					var bg = font.GetGeometry(H2, 10, text, textheight, 1300);
					var drawingVisual = new System.Windows.Media.DrawingVisual();
					var render = drawingVisual.RenderOpen();
					var P0 = new PathSource() { Thickness = H };
					P0.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.Red, null, P0.Geometry);
					var P1 = new PathSource() { Thickness = H - 2 };
					P1.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.Black, null, P1.Geometry);
					var P2 = new PathSource() { Thickness = H - 6 };
					P2.AddLin11(H2, H2, textwidth + H2, H2);
					render.DrawGeometry(Brushes.Red, null, P2.Geometry);
					render.DrawGeometry(Brushes.Black, null, bg);
					render.DrawGeometry(Brushes.Red, null, g);
					render.Close();
					_down = drawingVisual;
				}
				Child = _down;
				e.Handled = true;
			}
			base.OnMouseLeftButtonDown(e);
		}
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e) {
			if (downed) {
				if(entered) {
					Child = _enter;
					RoutedEventArgs ee = new RoutedEventArgs(ClickEvent, this);
					RaiseEvent(ee);
				} else {
					Child = _default;
				}
				downed = false;
				e.Handled = true;
			}
			base.OnMouseLeftButtonUp(e);
		}
		protected override Size MeasureOverride(Size availableSize) {
			return new Size(width, height);
		}

	}
}
