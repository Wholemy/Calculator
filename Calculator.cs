using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
namespace Wholemy {
	#region #class# Calculator 
	public class Calculator : System.Windows.Application {
		public static bool OpLeftMulEnable = true;
		public static bool OpLeftMulAddToStack = false;
		public static bool OpLeftMulValInStack = true;
		public const string ResRootPath = "pack://application:,,,/Wholemy.Calculator;component/";
		public readonly static string ResFontsPath = ResRootPath + "fonts/";
		public static int Weigf = 4;
		public const int WeigfMin = 1;
		public const int WeigfMax = 9;
		public static int Sizef = 30;
		public const int SizefMin = 8;
		public const int SizefMax = 800;
		public static bool Lowef = true;
		#region #field# FontOnceName 
		public readonly static string FontOnceName = "WholemyOnce";
		#endregion
		#region #field# FontOnce 
		public readonly static string[] FontOnce = new string[] {
			FontOnceName+ "100",
			FontOnceName+ "200",
			FontOnceName+ "300",
			FontOnceName+ "400",
			FontOnceName+ "500",
			FontOnceName+ "600",
			FontOnceName+ "700",
			FontOnceName+ "800",
			FontOnceName+ "900",
		};
		#endregion
		#region #field# FontLowerOnceName 
		public readonly static string FontLowerOnceName = "WholemyLowerOnce";
		#endregion
		#region #field# FontLowerOnce 
		public readonly static string[] FontLowerOnce = new string[] {
			FontLowerOnceName+ "100",
			FontLowerOnceName+ "200",
			FontLowerOnceName+ "300",
			FontLowerOnceName+ "400",
			FontLowerOnceName+ "500",
			FontLowerOnceName+ "600",
			FontLowerOnceName+ "700",
			FontLowerOnceName+ "800",
			FontLowerOnceName+ "900",
		};
		#endregion
		#region #method# GetOnce(I) 
		public static FontFamily GetOnce(int I) {
			var Name = Lowef ? Calculator.FontLowerOnce[--I] : Calculator.FontOnce[--I];
			var Uris = (Calculator.ResFontsPath + Name + ".ttf").ToLowerInvariant();
			return new FontFamily(new System.Uri(Uris), "./#" + Name);
		}
		#endregion
		public static Calculator App;
		public static MainWindow Window;
		public Calculator() { }
		[System.STAThread]
		public static void Main() {
			App = new Calculator();
			Window = new MainWindow();
			App.Run(Window);
		}
	}
	#endregion Application 
	#region #class# MainWindow 
	public class MainWindow : System.Windows.Window {
		public static readonly RoutedEvent WeigfEvent = EventManager.RegisterRoutedEvent("Weigf", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
		public event RoutedEventHandler Weigf {
			add {
				AddHandler(WeigfEvent, value);
			}
			remove {
				RemoveHandler(WeigfEvent, value);
			}
		}
		public static readonly RoutedEvent SizefEvent = EventManager.RegisterRoutedEvent("Sizef", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
		public event RoutedEventHandler Sizef {
			add {
				AddHandler(SizefEvent, value);
			}
			remove {
				RemoveHandler(SizefEvent, value);
			}
		}
		public static readonly RoutedEvent LowefEvent = EventManager.RegisterRoutedEvent("Lowef", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
		public event RoutedEventHandler Lowef {
			add {
				AddHandler(LowefEvent, value);
			}
			remove {
				RemoveHandler(LowefEvent, value);
			}
		}
		protected override void OnMouseDown(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseUp(e);
		}
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		public readonly System.Windows.Controls.ScrollViewer ScrollViewer = new System.Windows.Controls.ScrollViewer() {
			VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch
		};
		public readonly System.Windows.Controls.StackPanel VStack = new System.Windows.Controls.StackPanel() {
			Orientation = System.Windows.Controls.Orientation.Vertical,
			VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
		};
		public readonly System.Windows.Controls.TextBox TextOne = new System.Windows.Controls.TextBox() {
			Background = Colors.Background,
			Foreground = Colors.Foreground
		};
		public readonly System.Windows.Controls.TextBox TextTwo = new System.Windows.Controls.TextBox() {
			Background = Colors.Background,
			Foreground = Colors.Foreground
		};
		public readonly System.Windows.Controls.TextBox TextRes = new System.Windows.Controls.TextBox() {
			Background = Colors.Background,
			Foreground = Colors.Foreground
		};
		public readonly System.Windows.Controls.TextBox TextMod = new System.Windows.Controls.TextBox() {
			Background = Colors.Background,
			Foreground = Colors.Foreground
		};
		public readonly NumberBodrer A;
		public readonly NumberBodrer B;
		public readonly NumberBodrer R;
		public readonly NumberBodrer M;
		public readonly NumberBodrer Y;
		public readonly NumberBodrer X;
		public readonly TextBodrer T;
		public readonly DirectStackBorder D;
		public readonly GlobalFunctionBodrer Func;
		public readonly GlobalSettingsBodrer Glob;
		public MainWindow() {
			A = new NumberBodrer(this, "A");
			B = new NumberBodrer(this, "B");
			R = new NumberBodrer(this, "R");
			M = new NumberBodrer(this, "M");
			Y = new NumberBodrer(this, "Y");
			X = new NumberBodrer(this, "X");
			T = new TextBodrer(this, "T");
			D = new DirectStackBorder(this, "D");
			Func = new GlobalFunctionBodrer(this);
			Glob = new GlobalSettingsBodrer(this);
			this.WindowState = System.Windows.WindowState.Normal;
			this.Title = "Весьмой калькулятор";
			Background = Colors.Background;
			Foreground = Colors.Foreground;
			this.Content = ScrollViewer;
			ScrollViewer.Content = VStack;
			VStack.Children.Add(Glob);
			VStack.Children.Add(Func);
			VStack.Children.Add(A);
			VStack.Children.Add(B);
			VStack.Children.Add(R);
			VStack.Children.Add(M);
			VStack.Children.Add(Y);
			VStack.Children.Add(X);
			VStack.Children.Add(T);
			VStack.Children.Add(D);
		}

		public void WeigfRaise(int Value) {
			if (Value < Calculator.WeigfMin) Value = Calculator.WeigfMin;
			if (Value > Calculator.WeigfMax) Value = Calculator.WeigfMax;
			if (Value != Calculator.Weigf) {
				Calculator.Weigf = Value;
				RoutedEventArgs ee = new RoutedEventArgs(WeigfEvent, Parent);
				RaiseEvent(ee);
			}
		}
		public void SizefRaise(int Value) {
			if (Value < Calculator.SizefMin) Value = Calculator.SizefMin;
			if (Value > Calculator.SizefMax) Value = Calculator.SizefMax;
			if (Value != Calculator.Sizef) {
				Calculator.Sizef = Value;
				RoutedEventArgs ee = new RoutedEventArgs(SizefEvent, Parent);
				RaiseEvent(ee);
			}
		}
		public void LowefRaise(bool Value) {
			if (Value != Calculator.Lowef) {
				Calculator.Lowef = Value;
				RoutedEventArgs ee = new RoutedEventArgs(LowefEvent, Parent);
				RaiseEvent(ee);
			}
		}
	}
	#endregion
	#region #class# GlobalSettingsBodrer 
	public class GlobalSettingsBodrer : System.Windows.Controls.Border {
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal
		};
		public readonly System.Windows.Controls.TextBox TextDepth = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2, 2, 2, 2),
			MinWidth = 10
		};
		public readonly System.Windows.Controls.TextBox TextChars = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2, 2, 2, 2),
			MinWidth = 10
		};
		public readonly System.Windows.Controls.TextBox TextWeigf = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2, 2, 2, 2),
			MinWidth = 10
		};
		public readonly System.Windows.Controls.TextBox TextSizef = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2, 2, 2, 2),
			MinWidth = 10
		};
		public readonly System.Windows.Controls.CheckBox CheckLowef = new System.Windows.Controls.CheckBox() {
			Content = "Нижний регистр цифр",
			Margin = new System.Windows.Thickness(2),
			Foreground = Colors.Foreground,
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			VerticalAlignment = System.Windows.VerticalAlignment.Center,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left
		};
		public readonly new MainWindow Parent;
		public GlobalSettingsBodrer(MainWindow Parent) {
			this.Parent = Parent;
			this.Child = PanelMain;
			var LabelDepth = new System.Windows.Controls.Label() { Content = "Макс дроби", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
			var LabelChars = new System.Windows.Controls.Label() { Content = "В результате", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
			var LabelWeigf = new System.Windows.Controls.Label() { Content = "Толщина цифр", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
			var LabelSizef = new System.Windows.Controls.Label() { Content = "Размер цифр", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
			PanelMain.Children.Add(LabelDepth);
			PanelMain.Children.Add(TextDepth);
			PanelMain.Children.Add(LabelChars);
			PanelMain.Children.Add(TextChars);
			PanelMain.Children.Add(LabelWeigf);
			PanelMain.Children.Add(TextWeigf);
			PanelMain.Children.Add(LabelSizef);
			PanelMain.Children.Add(TextSizef);
			PanelMain.Children.Add(CheckLowef);
			TextDepth.TextChanged += TextDepth_TextChanged;
			TextChars.TextChanged += TextChars_TextChanged;
			TextDepth.Text = BugNum.MaxDepth.ToString();
			TextChars.Text = BugNum.MaxChars.ToString();
			TextWeigf.Text = Calculator.Weigf.ToString();
			TextWeigf.TextChanged += TextWeigf_TextChanged;
			TextSizef.Text = Calculator.Sizef.ToString();
			TextSizef.TextChanged += TextSizef_TextChanged;
			CheckLowef.IsChecked = Calculator.Lowef;
			CheckLowef.Checked += CheckLowef_Checked;
			CheckLowef.Unchecked += CheckLowef_Unchecked;
		}

		private void CheckLowef_Unchecked(object sender, RoutedEventArgs e) {
			Parent.LowefRaise(false);
		}
		private void CheckLowef_Checked(object sender, RoutedEventArgs e) {
			Parent.LowefRaise(true);
		}
		private void TextSizef_TextChanged(object sender, TextChangedEventArgs e) {
			try {
				Parent.SizefRaise(int.Parse(TextSizef.Text));
			} finally {
				TextSizef.Text = Calculator.Sizef.ToString();
			}
		}
		private void TextWeigf_TextChanged(object sender, TextChangedEventArgs e) {
			try {
				Parent.WeigfRaise(int.Parse(TextWeigf.Text));
			} finally {
				TextWeigf.Text = Calculator.Weigf.ToString();
			}
		}

		private void TextDepth_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
			if (int.TryParse(TextDepth.Text, out int R) && R >= 0) {
				BugNum.MaxDepth = R;
			}
			TextDepth.Text = BugNum.MaxDepth.ToString();
			TextChars.Text = BugNum.MaxChars.ToString();
		}
		private void TextChars_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
			if (int.TryParse(TextChars.Text, out int R) && R >= 0) {
				BugNum.MaxChars = R;
			}
			TextChars.Text = BugNum.MaxChars.ToString();
		}
	}
	#endregion
	#region #class# GlobalFunctionBodrer 
	public class GlobalFunctionBodrer : System.Windows.Controls.Border {
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal,
			Margin = new System.Windows.Thickness(0, 0, 8, 8),
		};
		public readonly Button ButtonA = new Button("A", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonB = new Button("B", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonR = new Button("R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonM = new Button("M", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonY = new Button("Y", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonX = new Button("X", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonT = new Button("T", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonD = new Button("D", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAaddBequR = new Button("A + B = R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAsubBequR = new Button("A - B = R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAmulBequR = new Button("A * B = R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAdivBequR = new Button("A / B = R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAmodBequR = new Button("A % B = R", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAdivBequRmodM = new Button("A / B = R % M", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonXsqrtR = new Button("R = Sqrt(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonXsinR = new Button("R = Sin(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonXcosR = new Button("R = Cos(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonXtanR = new Button("R = Tan(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonXatanR = new Button("R = Atan(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonYXatan2R = new Button("R = Atan2(Y,X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonYXatanOfTanR = new Button("R = AtanOfTan(X)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonPI = new Button("R = PI(10K)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly new MainWindow Parent;
		public GlobalFunctionBodrer(MainWindow Parent) {
			this.Parent = Parent;
			this.Child = PanelMain;
			ButtonA.Click += ButtonA_Click;
			PanelMain.Children.Add(ButtonA);
			ButtonB.Click += ButtonB_Click;
			PanelMain.Children.Add(ButtonB);
			ButtonR.Click += ButtonR_Click;
			PanelMain.Children.Add(ButtonR);
			ButtonM.Click += ButtonM_Click;
			PanelMain.Children.Add(ButtonM);
			ButtonY.Click += ButtonY_Click;
			PanelMain.Children.Add(ButtonY);
			ButtonX.Click += ButtonX_Click;
			PanelMain.Children.Add(ButtonX);
			ButtonT.Click += ButtonT_Click;
			PanelMain.Children.Add(ButtonT);
			ButtonD.Click += ButtonD_Click;
			PanelMain.Children.Add(ButtonD);
			ButtonAaddBequR.Click += ButtonAaddBequR_Click;
			PanelMain.Children.Add(ButtonAaddBequR);
			ButtonAsubBequR.Click += ButtonAsubBequR_Click;
			PanelMain.Children.Add(ButtonAsubBequR);
			ButtonAmulBequR.Click += ButtonAmulBequR_Click;
			PanelMain.Children.Add(ButtonAmulBequR);
			ButtonAdivBequR.Click += ButtonAdivBequR_Click;
			PanelMain.Children.Add(ButtonAdivBequR);
			ButtonAmodBequR.Click += ButtonAmodBequR_Click;
			PanelMain.Children.Add(ButtonAmodBequR);
			ButtonAdivBequRmodM.Click += ButtonAdivBequRmodM_Click;
			PanelMain.Children.Add(ButtonAdivBequRmodM);
			ButtonXsqrtR.Click += ButtonXsqrtR_Click;
			PanelMain.Children.Add(ButtonXsqrtR);
			ButtonXsinR.Click += ButtonXsinR_Click;
			PanelMain.Children.Add(ButtonXsinR);
			ButtonXcosR.Click += ButtonXcosR_Click;
			PanelMain.Children.Add(ButtonXcosR);
			ButtonXtanR.Click += ButtonXtanR_Click;
			PanelMain.Children.Add(ButtonXtanR);
			ButtonXatanR.Click += ButtonXatanR_Click;
			PanelMain.Children.Add(ButtonXatanR);
			ButtonYXatan2R.Click += ButtonYXatan2R_Click;
			PanelMain.Children.Add(ButtonYXatan2R);
			ButtonYXatanOfTanR.Click += ButtonYXatanOfTanR_Click;
			PanelMain.Children.Add(ButtonYXatanOfTanR);
			ButtonPI.Click += ButtonPI_Click;
			PanelMain.Children.Add(ButtonPI);
		}

		private void ButtonD_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.D.Visibility != Visibility.Visible)
				this.Parent.D.Visibility = Visibility.Visible;
			else this.Parent.D.Visibility = Visibility.Collapsed;
		}

		private void ButtonT_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.T.Visibility != Visibility.Visible)
				this.Parent.T.Visibility = Visibility.Visible;
			else this.Parent.T.Visibility = Visibility.Collapsed;
		}

		private void ButtonX_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.X.Visibility != Visibility.Visible)
				this.Parent.X.Visibility = Visibility.Visible;
			else this.Parent.X.Visibility = Visibility.Collapsed;
		}

		private void ButtonY_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.Y.Visibility != Visibility.Visible)
				this.Parent.Y.Visibility = Visibility.Visible;
			else this.Parent.Y.Visibility = Visibility.Collapsed;
		}

		private void ButtonM_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.M.Visibility != Visibility.Visible)
				this.Parent.M.Visibility = Visibility.Visible;
			else this.Parent.M.Visibility = Visibility.Collapsed;
		}

		private void ButtonR_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.R.Visibility != Visibility.Visible)
				this.Parent.R.Visibility = Visibility.Visible;
			else this.Parent.R.Visibility = Visibility.Collapsed;
		}

		private void ButtonB_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.B.Visibility != Visibility.Visible)
				this.Parent.B.Visibility = Visibility.Visible;
			else this.Parent.B.Visibility = Visibility.Collapsed;
		}

		private void ButtonA_Click(object sender, RoutedEventArgs e) {
			if (this.Parent.A.Visibility != Visibility.Visible)
				this.Parent.A.Visibility = Visibility.Visible;
			else this.Parent.A.Visibility = Visibility.Collapsed;
		}

		private void ButtonPI_Click(object sender, RoutedEventArgs e) {
			this.Parent.R.Number = BugNum.PI;
			this.Parent.R.Visibility = Visibility.Visible;
		}

		private void ButtonYXatanOfTanR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TAtanOfTan(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonYXatan2R_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TAtan2(this.Parent.Y.Number, this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAmodBequR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = this.Parent.A.Number % this.Parent.B.Number;
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonXatanR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TAtan(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonXtanR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TTan(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonXcosR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TCos(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonXsinR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.TSin(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonXsqrtR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = BugNum.Sqrt(this.Parent.X.Number);
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAdivBequRmodM_Click(object sender, RoutedEventArgs e) {
			try {
				var A = this.Parent.A.Number;
				var B = this.Parent.B.Number;
				this.Parent.R.Number = BugInt.DivMod(A.Numer / A.Venom, B.Numer / B.Venom, out var M);
				this.Parent.M.Number = M;
				this.Parent.R.Visibility = Visibility.Visible;
				this.Parent.M.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAdivBequR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = this.Parent.A.Number / this.Parent.B.Number;
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAmulBequR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = this.Parent.A.Number * this.Parent.B.Number;
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAsubBequR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = this.Parent.A.Number - this.Parent.B.Number;
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}

		private void ButtonAaddBequR_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.R.Number = this.Parent.A.Number + this.Parent.B.Number;
				this.Parent.R.Visibility = Visibility.Visible;
			} catch { }
		}
	}
	#endregion
	#region #class# NumberBodrer 
	public class NumberBodrer : System.Windows.Controls.Border {
		public BugNum Num;

		protected override void OnMouseDown(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseUp(e);
		}
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		public readonly System.Windows.Controls.TextBox TextValue = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		public readonly System.Windows.Controls.TextBox TextNumer = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Visibility = System.Windows.Visibility.Collapsed,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)

		};
		public readonly System.Windows.Controls.TextBox TextVenom = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Visibility = System.Windows.Visibility.Collapsed,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		public readonly System.Windows.Controls.Grid GridMain = new System.Windows.Controls.Grid() {

		};
		public readonly NumberSettingsBodrer Settings;
		public readonly new MainWindow Parent;
		public NumberBodrer(MainWindow Parent, string Name) {
			this.Parent = Parent;
			Parent.Weigf += Parent_Weigf;
			Parent.Sizef += Parent_Sizef;
			Parent.Lowef += Parent_Lowef;
			this.NumberName = Name;
			Settings = new NumberSettingsBodrer(this);
			this.BorderThickness = new System.Windows.Thickness(2, 2, 2, 2);
			TextValue.TextChanged += TextValue_TextChanged;
			TextNumer.TextChanged += TextNumer_TextChanged;
			TextVenom.TextChanged += TextVenom_TextChanged;
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			this.Child = GridMain;
			GridMain.Children.Add(Settings);
			GridMain.Children.Add(TextValue);
			GridMain.Children.Add(TextNumer);
			GridMain.Children.Add(TextVenom);
			System.Windows.Controls.Grid.SetRow(Settings, 0);
			System.Windows.Controls.Grid.SetRow(TextValue, 1);
			System.Windows.Controls.Grid.SetRow(TextNumer, 2);
			System.Windows.Controls.Grid.SetRow(TextVenom, 3);
			this.BorderBrush = new System.Windows.Media.SolidColorBrush(FgColor);
		}

		private void Parent_Lowef(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextNumer.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextVenom.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}

		private void Parent_Sizef(object sender, RoutedEventArgs e) {
			TextValue.FontSize = Calculator.Sizef;
			TextNumer.FontSize = Calculator.Sizef;
			TextVenom.FontSize = Calculator.Sizef;
		}

		private void Parent_Weigf(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextNumer.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextVenom.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}

		bool CH = false;
		internal string NumberName;
		public BugNum Number {
			get { return Num; }
			set {
				if (!CH) {
					try {
						CH = true;
						if (Settings.Gcd) value = value.GcdNum;
						TextValue.Text = value.ToString();
						TextNumer.Text = value.Numer.ToString();
						TextVenom.Text = value.Venom.ToString();
						Num = value;
					} catch { }
					CH = false;
				}
			}
		}
		private void TextVenom_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
			if (!CH) {
				try {
					CH = true;
					var Numer = new BugInt(TextNumer.Text);
					var Venom = new BugInt(TextVenom.Text);
					Num = new BugNum(Numer, Venom);
					TextValue.Text = Num.ToString();
				} catch {

				}
				CH = false;
			}
		}

		private void TextNumer_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
			if (!CH) {
				try {
					CH = true;
					var Numer = new BugInt(TextNumer.Text);
					var Venom = new BugInt(TextVenom.Text);
					Num = new BugNum(Numer, Venom);
					TextValue.Text = Num.ToString();
				} catch { }
				CH = false;
			}
		}

		private void TextValue_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
			if (!CH) {
				try {
					CH = true;
					Num = new BugNum(TextValue.Text);
					if (Settings.Gcd) Num = Num.GcdNum;
					TextNumer.Text = Num.Numer.ToString();
					TextVenom.Text = Num.Venom.ToString();
				} catch { }
				CH = false;
			}
		}
	}
	#endregion
	#region #class# NumberSettingsBodrer 
	public class NumberSettingsBodrer : System.Windows.Controls.Border {
		public NumberBodrer Parent;
		public bool Gcd;
		#region #field# #static# BgColor 
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		#endregion
		#region #field# #static# FgColor 
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		#endregion
		#region #field# #readonly# PanelMain 
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal
		};
		#endregion
		#region #field# #readonly# NumberLabel 
		public readonly Button NumberLabel;
		#endregion
		#region #field# #readonly# CheckNumer 
		public readonly System.Windows.Controls.CheckBox CheckNumer = new System.Windows.Controls.CheckBox() {
			IsChecked = false,
			Content = "Делимое",
			Margin = new System.Windows.Thickness(2),
			Foreground = Colors.Foreground,
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			VerticalAlignment = System.Windows.VerticalAlignment.Center,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left
		};
		#endregion
		#region #field# #readonly# CheckVenom 
		public readonly System.Windows.Controls.CheckBox CheckVenom = new System.Windows.Controls.CheckBox() {
			IsChecked = false,
			Content = "Делитель",
			Margin = new System.Windows.Thickness(2),
			Foreground = Colors.Foreground,
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			VerticalAlignment = System.Windows.VerticalAlignment.Center,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left
		};
		#endregion
		#region #field# #readonly# GcdCombo 
		public readonly System.Windows.Controls.CheckBox CheckGcd = new System.Windows.Controls.CheckBox() {
			Foreground = Colors.Foreground,
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			VerticalAlignment = System.Windows.VerticalAlignment.Center,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Left,
			IsChecked = false,
			Content = "Уменьшать",
		};
		#endregion
		public NumberSettingsBodrer(NumberBodrer Parent) {
			this.Parent = Parent;
			//this.BorderThickness = new System.Windows.Thickness(2, 2, 2, 2);
			//this.BorderBrush = Colors.Foreground;
			this.Child = PanelMain;
			NumberLabel = new Button(Parent.NumberName, Font277.Instance, 20) { Margin = new Thickness(8) };
			NumberLabel.Click += NumberLabel_Click;
			PanelMain.Children.Add(NumberLabel);
			CheckNumer.Checked += CheckNumer_Checked;
			CheckNumer.Unchecked += CheckNumer_Unchecked;
			PanelMain.Children.Add(CheckNumer);
			CheckVenom.Checked += CheckVenom_Checked;
			CheckVenom.Unchecked += CheckVenom_Unchecked;
			PanelMain.Children.Add(CheckVenom);
			CheckGcd.Checked += CheckGcd_Checked;
			CheckGcd.Unchecked += CheckGcd_Unchecked;
			PanelMain.Children.Add(CheckGcd);
		}

		private void NumberLabel_Click(object sender, RoutedEventArgs e) {
			Parent.Visibility = Visibility.Collapsed;
		}

		private void CheckGcd_Unchecked(object sender, RoutedEventArgs e) {
			Gcd = false;
		}
		private void CheckGcd_Checked(object sender, RoutedEventArgs e) {
			Gcd = true;
			var T = Parent.Num = Parent.Num.GcdNum;
			Parent.TextNumer.Text = T.Numer.ToString();
			Parent.TextVenom.Text = T.Venom.ToString();
		}
		private void CheckNumer_Unchecked(object sender, System.Windows.RoutedEventArgs e) {
			Parent.TextNumer.Visibility = System.Windows.Visibility.Collapsed;
		}
		private void CheckNumer_Checked(object sender, System.Windows.RoutedEventArgs e) {
			Parent.TextNumer.Visibility = System.Windows.Visibility.Visible;
		}
		private void CheckVenom_Unchecked(object sender, System.Windows.RoutedEventArgs e) {
			Parent.TextVenom.Visibility = System.Windows.Visibility.Collapsed;
		}
		private void CheckVenom_Checked(object sender, System.Windows.RoutedEventArgs e) {
			Parent.TextVenom.Visibility = System.Windows.Visibility.Visible;
		}
	}
	#endregion
	#region #class# DirectButton 
	public class DirectButton : Button {
		public DirectBodrer D;
		public DirectButton(DirectBodrer D, string text, PathFont font, double height) : base(text, font, height) {
			this.D = D;
			D = null;
		}
	}
	#endregion
	#region #class# DirectStackBorder 
	public class DirectStackBorder : System.Windows.Controls.Border {
		#region #field# GridMain 
		public readonly System.Windows.Controls.Grid GridMain = new System.Windows.Controls.Grid() {

		};
		#endregion
		#region #field# PanelMain 
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal,
			Margin = new System.Windows.Thickness(0, 0, 8, 8),
		};
		#endregion
		#region #field# StackMain 
		public readonly System.Windows.Controls.StackPanel StackMain = new System.Windows.Controls.StackPanel() {
			Orientation = System.Windows.Controls.Orientation.Vertical,
			VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
			HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
		};
		#endregion
		public readonly new MainWindow Parent;
		public readonly Button Label;
		public readonly Button Adder;
		public readonly Button Suber;
		public System.Collections.Generic.List<DirectButton> Buttons = new System.Collections.Generic.List<DirectButton>();
		public DirectStackBorder(MainWindow Parent, string Name) {
			this.Parent = Parent;
			this.Child = GridMain;
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			System.Windows.Controls.Grid.SetRow(PanelMain, 0);
			System.Windows.Controls.Grid.SetRow(StackMain, 1);
			GridMain.Children.Add(PanelMain);
			GridMain.Children.Add(StackMain);
			this.Label = new Button(Name, Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.Label.Click += Label_Click;
			PanelMain.Children.Add(Label);
			this.Adder = new Button("D++", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.Adder.Click += Adder_Click;
			PanelMain.Children.Add(Adder);
			this.Suber = new Button("D--", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.Suber.Click += Suber_Click;
			PanelMain.Children.Add(Suber);
			Adder_Click(null, null);
		}

		private void Suber_Click(object sender, RoutedEventArgs e) {
			var I = Buttons.Count;
			if (I > 0) {
				I--;
				var B = Buttons[I];
				B.Click -= B_Click;
				StackMain.Children.Remove(B.D);
				PanelMain.Children.Remove(B);
				B.D.Removed();
				Buttons.Remove(B);
			}
		}

		private void Adder_Click(object sender, RoutedEventArgs e) {
			var N = "D" + Buttons.Count;
			var D = new DirectBodrer(this, N);
			var B = new DirectButton(D, N, Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			B.Click += B_Click;
			Buttons.Add(B);
			StackMain.Children.Add(D);
			PanelMain.Children.Add(B);
		}
		public void AddCopy(string text) {
			var N = "D" + Buttons.Count;
			var D = new DirectBodrer(this, N);
			var B = new DirectButton(D, N, Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			B.Click += B_Click;
			Buttons.Add(B);
			StackMain.Children.Add(D);
			PanelMain.Children.Add(B);
			D.TextValue.Text = text;
			D.TextValue.CaretIndex = text.Length;
		}
		private void B_Click(object sender, RoutedEventArgs e) {
			var B = sender as DirectButton;
			if (B != null) {
				if (B.D.Visibility != Visibility.Visible)
					B.D.Visibility = Visibility.Visible;
				else B.D.Visibility = Visibility.Collapsed;
			}
		}
		#region #method# Label_Click(sender, e) 
		private void Label_Click(object sender, RoutedEventArgs e) {
			this.Visibility = Visibility.Collapsed;
		}

		#endregion
	}
	#endregion
	#region #class# DirectBodrer 
	public class DirectBodrer : System.Windows.Controls.Border {
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		#region #field# TextValue 
		public readonly System.Windows.Controls.TextBox TextValue = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			AcceptsTab = true,
			AcceptsReturn = true,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		#endregion
		#region #field# TextResult 
		public readonly System.Windows.Controls.TextBox TextResult = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			AcceptsTab = true,
			AcceptsReturn = true,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		#endregion
		#region #field# GridMain 
		public readonly System.Windows.Controls.Grid GridMain = new System.Windows.Controls.Grid() {

		};
		#endregion
		#region #field# PanelMain 
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal,
			Margin = new System.Windows.Thickness(0, 0, 8, 8),
		};
		#endregion
		public readonly new DirectStackBorder Parent;
		public readonly Button Label;
		public readonly Button DCopy;
		public readonly Button NDot;
		public readonly Button NCom;
		public readonly Button N0;
		public readonly Button N1;
		public readonly Button N2;
		public readonly Button N3;
		public readonly Button N4;
		public readonly Button N5;
		public readonly Button N6;
		public readonly Button N7;
		public readonly Button N8;
		public readonly Button N9;
		public readonly Button PL;
		public readonly Button Plr;
		public readonly Button PR;
		public readonly Button FAdd;
		public readonly Button FSub;
		public readonly Button FMul;
		public readonly Button FDiv;
		public readonly Button FMod;
		public readonly Button CBackspace;
		#region #new# (Parent, Name) 
		public DirectBodrer(DirectStackBorder Parent, string Name) {
			this.Parent = Parent;
			this.DCopy = new Button("D++", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.NDot = new Button(".", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.NCom = new Button(",", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N0 = new Button("0", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N1 = new Button("1", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N2 = new Button("2", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N3 = new Button("3", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N4 = new Button("4", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N5 = new Button("5", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N6 = new Button("6", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N7 = new Button("7", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N8 = new Button("8", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.N9 = new Button("9", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.PL = new Button("(", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.Plr = new Button("()", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.PR = new Button(")", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.FAdd = new Button("+", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.FSub = new Button("-", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.FMul = new Button("*", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.FDiv = new Button("/", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.FMod = new Button("%", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.CBackspace = new Button("<-", Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			Parent.Parent.Weigf += Parent_Weigf;
			Parent.Parent.Sizef += Parent_Sizef;
			Parent.Parent.Lowef += Parent_Lowef;
			this.BorderThickness = new System.Windows.Thickness(2, 2, 2, 2);
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			this.Child = GridMain;
			GridMain.Children.Add(PanelMain);
			GridMain.Children.Add(TextValue);
			TextValue.TextChanged += TextValue_TextChanged;
			GridMain.Children.Add(TextResult);
			System.Windows.Controls.Grid.SetRow(PanelMain, 0);
			System.Windows.Controls.Grid.SetRow(TextValue, 1);
			System.Windows.Controls.Grid.SetRow(TextResult, 2);
			this.BorderBrush = new System.Windows.Media.SolidColorBrush(FgColor);
			this.Label = new Button(Name, Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			this.Label.Click += Label_Click;
			PanelMain.Children.Add(Label);
			DCopy.Click += DCopy_Click;
			PanelMain.Children.Add(DCopy);
			PanelMain.Children.Add(NDot);
			NDot.Click += N_Click;
			NDot.Enter += N_Enter;
			PanelMain.Children.Add(NCom);
			NCom.Click += N_Click;
			NCom.Enter += N_Enter;
			PanelMain.Children.Add(N0);
			N0.Click += N_Click;
			N0.Enter += N_Enter;
			PanelMain.Children.Add(N1);
			N1.Click += N_Click;
			N1.Enter += N_Enter;
			PanelMain.Children.Add(N2);
			N2.Click += N_Click;
			N2.Enter += N_Enter;
			PanelMain.Children.Add(N3);
			N3.Click += N_Click;
			N3.Enter += N_Enter;
			PanelMain.Children.Add(N4);
			N4.Click += N_Click;
			N4.Enter += N_Enter;
			PanelMain.Children.Add(N5);
			N5.Click += N_Click;
			N5.Enter += N_Enter;
			PanelMain.Children.Add(N6);
			N6.Click += N_Click;
			N6.Enter += N_Enter;
			PanelMain.Children.Add(N7);
			N7.Click += N_Click;
			N7.Enter += N_Enter;
			PanelMain.Children.Add(N8);
			N8.Click += N_Click;
			N8.Enter += N_Enter;
			PanelMain.Children.Add(N9);
			N9.Click += N_Click;
			N9.Enter += N_Enter;
			PanelMain.Children.Add(PL);
			PL.Click += N_Click;
			PL.Enter += N_Enter;
			PanelMain.Children.Add(Plr);
			Plr.Click += Plr_Click;
			Plr.Enter += N_Enter;
			PanelMain.Children.Add(PR);
			PR.Click += N_Click;
			PR.Enter += N_Enter;
			PanelMain.Children.Add(FAdd);
			FAdd.Click += N_Click;
			FAdd.Enter += N_Enter;
			PanelMain.Children.Add(FSub);
			FSub.Click += N_Click;
			FSub.Enter += N_Enter;
			PanelMain.Children.Add(FMul);
			FMul.Click += N_Click;
			FMul.Enter += N_Enter;
			PanelMain.Children.Add(FDiv);
			FDiv.Click += N_Click;
			FDiv.Enter += N_Enter;
			PanelMain.Children.Add(FMod);
			FMod.Click += N_Click;
			FMod.Enter += N_Enter;
			PanelMain.Children.Add(CBackspace);
			CBackspace.Click += CBackspace_Click;
			CBackspace.Enter += N_Enter;
		}

		private void DCopy_Click(object sender, RoutedEventArgs e) {
			Parent.AddCopy(TextValue.Text);
		}
		#endregion
		#region #method# Removed 
		public void Removed() {
			Parent.Parent.Weigf -= Parent_Weigf;
			Parent.Parent.Sizef -= Parent_Sizef;
			Parent.Parent.Lowef -= Parent_Lowef;
		}
		#endregion
		#region #method# Plr_Click(sender, e) 
		private void Plr_Click(object sender, RoutedEventArgs e) {
			var D = sender as Button;
			var I = TextValue.CaretIndex;
			var C = TextValue.SelectionLength;
			var V = TextValue.Text;
			if (C > 0) {
				I = TextValue.SelectionStart;
				TextValue.Text = V.Insert(I, "(").Insert(I + C + 1, ")");
				TextValue.CaretIndex = I + C + 2;
			} else {
				TextValue.Text = V.Insert(I, "()");
				TextValue.CaretIndex = I + 2;
			}
		}
		#endregion

		#region #class# DepthStack 
		private class DepthStack {
			public readonly char Char;
			public readonly int Index;
			public readonly int Depth;
			public bool IsEnded;
			public ValueStack Value;
			public string OpWord;
			public OperStack OpLeft;
			public OperStack SetOpLeft = null;
			public OperStack Operator;
			public readonly DepthStack Next;
			public DepthStack(char Char, int Index, DepthStack Next) {
				this.Index = Index;
				this.Next = Next;
				if (Next != null) this.Depth = Next.Depth + 1; else this.Depth = 1;
			}
		}
		#endregion
		#region #class# OperStack 
		private class OperStack {
			public readonly char Char;
			public readonly int Index;
			public readonly int Depth;
			public OperStack Next;
			public OperStack(char Char, int Index, int Depth, OperStack Next) {
				this.Char = Char;
				this.Index = Index;
				this.Next = Next;
				this.Depth = Depth;
			}
			public OperStack Invert() {
				OperStack T = this;
				OperStack R = null;
				while (T != null) {
					R = new OperStack(T.Char, T.Depth, T.Index, R);
					T = T.Next;
				}
				return R;
			}
			public class St {
				public BugNum Value;
				public St Below;
				public St(BugNum Value, St Below) {
					this.Value = Value;
					this.Below = Below;
				}
			}
			public BugNum Apply(BugNum V) {
				var OpLeft = this.Invert();
				var O = false;
				var I = 0;
				St S = null;
				while (OpLeft != null) {
					switch (OpLeft.Char) {
						case '!': if (O) { O = !O; } else { V = -V; } break;
						case '-': if (O) { V -= 1; } else { if (I == 0) { if (V >= 0) V = -V; } else { if (S != null) { if (S.Value != 0) V -= S.Value; S = S.Below; } else { V -= V; } } } break;
						case '+': if (O) { S = new St(V, S); V += 1; } else { if (I == 0) { if (V < 0) V = +V; } else { S = new St(V, S); V += V; } } break;
						case '*': S = new St(V, S); V *= V;
							//if (Calculator.OpLeftMulEnable) {
							//	var SS = S;
							//	if (Calculator.OpLeftMulAddToStack) { S = new St(V, S); }
							//	if (Calculator.OpLeftMulValInStack) { if(SS != null) V *= SS.Value; } else { V *= V; }
							//}
							break;
						case '/': if (S != null) { if (S.Value != 0) V /= S.Value; S = S.Below; } else { if (V != 0) V /= V; } break;
						case '%': if (S != null) { if (S.Value != 0) V %= S.Value; S = S.Below; } else { if (V != 0) V %= V; } break;
						case '=': O = !O; I = 0; S = null; break;
						case '?': break;
					}
					OpLeft = OpLeft.Next;
					I++;
				}
				return V;
			}
			public bool IsPrimary {
				get {
					var C = this.Char;
					return C == '*' || C == '/' || C == '%';
				}
			}
			public override string ToString() {
				OperStack T = this;
				string R = "";
				while (T != null) {
					R += T.Char;
					T = T.Next;
				}
				return R;
			}
		}
		#endregion
		#region #class# ValueStack 
		private class ValueStack {
			public BugNum Value;
			public OperStack OpLeft;
			public OperStack Operator;
			public readonly int Index;
			public readonly int Depth;
			public ValueStack Next;
			public ValueStack(BugNum Value, int Index, int Depth, ValueStack Next) {
				if (Next != null && Next.Operator != null) {
					Next.Operator = Next.Operator.Invert();
				}
				this.Value = Value;
				this.Index = Index;
				this.Next = Next;
				this.Depth = Depth;
			}
			public BugNum End(string Word) {
				ValueStack A = null;
				ValueStack B = null;
				var P = true;
			Next:
				ValueStack PB = null;
				ValueStack NA = this;
				while (NA.Next != null) {
					PB = NA;
					NA = NA.Next;
					if (P) {
						var NOp = NA.Operator;
						if (NOp != null && NOp.IsPrimary) { A = NA; B = PB; }
					}
				}
				if (!P) {
					A = NA; B = PB;
				}
				if (B != null) {
					if (A != null) {
						if (A.OpLeft != null) {
							A.Value = A.OpLeft.Apply(A.Value);
							A.OpLeft = null;
						}
						if (B.OpLeft != null) {
							B.Value = B.OpLeft.Apply(B.Value);
							B.OpLeft = null;
						}
						while (A.Operator != null) {
							switch (A.Operator.Char) {
								case '*': A.Value *= B.Value; break;
								case '/': if (B.Value != 0) A.Value /= B.Value; break;
								case '%': if (B.Value != 0) A.Value %= B.Value; break;
								case '-': A.Value -= B.Value; break;
								case '+': A.Value += B.Value; break;
							}
							A.Operator = A.Operator.Next;
						}
						B.Value = A.Value;
						B.Next = A.Next;
						A.Next = null; A = null; B = null;
						goto Next;
					} else if (P) {
						P = false;
						goto Next;
					}
				} else if (P) {
					P = false;
					goto Next;
				}
				if (this.OpLeft != null) {
					this.Value = this.OpLeft.Apply(this.Value);
					this.OpLeft = null;
				}
				switch (Word) {
					case "sqrt": this.Value = BugNum.Sqrt(this.Value); break;
					case "cos": this.Value = BugNum.TCos(this.Value); break;
					case "sin": this.Value = BugNum.TSin(this.Value); break;
					case "tan": this.Value = BugNum.TTan(this.Value); break;
					case "atan": this.Value = BugNum.TAtan(this.Value); break;
					case "atanoftan": this.Value = BugNum.TAtanOfTan(this.Value); break;
					case "pos": if (this.Value < 0) this.Value = +this.Value; break;
					case "neg": if (this.Value >= 0) this.Value = -this.Value; break;
					case "not": this.Value = -this.Value; break;
				}
				return this.Value;
			}
			public override string ToString() {
				ValueStack T = this;
				string R = "";
				while (T != null) {
					if (T.Operator != null) {
						if (T.OpLeft != null) {
							R = T.OpLeft.Char + T.Value.ToString() + T.Operator.ToString() + R;
						} else {
							R = T.Value.ToString() + T.Operator.ToString() + R;
						}
					} else {
						if (T.OpLeft != null) {
							R = T.OpLeft.Char + T.Value.ToString() + R;
						} else {
							R = T.Value.ToString() + R;
						}
					}
					T = T.Next;
				}
				return R;
			}
		}
		#endregion
		#region #method# TextValue_TextChanged(sender, e) 
		private void TextValue_TextChanged(object sender, TextChangedEventArgs e) {
			var Chars = TextValue.Text;
			OperStack Operator = null;
			OperStack SetOpLeft = null;
			bool SetOpLeftEnable = false;
			DepthStack DepthStack = null;
			string OpWord = null;
			var Depth = 0;
			ValueStack Value = null;
			var Start = 0;
			BugNum V;

			string S;
			for (int i = 0; i < Chars.Length; i++) {
				var Char = Chars[i];
				switch (Char) {
					case ';': {
							if (DepthStack != null) {
								if (DepthStack.Value == null) DepthStack.SetOpLeft = DepthStack.Operator; DepthStack.Operator = null;
							} else {
								if (Value == null) SetOpLeft = Operator; Operator = null;
							}
							SetOpLeftEnable = true;
						}
						break;
					case '(': {
							if (DepthStack != null && DepthStack.IsEnded == false) {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										DepthStack.Value = new ValueStack(V, i - 1, Depth, DepthStack.Value);
									}
								}
								var Op = DepthStack.Operator;
								DepthStack.Operator = null;
								var SOp = DepthStack.SetOpLeft;
								DepthStack.SetOpLeft = null;
								if (DepthStack.Value != null) {
									if (SOp != null) { DepthStack.Value.OpLeft = SOp; SOp = null; } else if (Op != null) { DepthStack.Value.OpLeft = Op; Op = null; }
								}
								if (DepthStack.Value != null && DepthStack.Value.Operator == null) DepthStack.Value.Operator = new OperStack('*', i, DepthStack.Depth, null);
								DepthStack = new DepthStack(Char, i, DepthStack);
								if (OpWord != null) {
									DepthStack.OpWord = OpWord;
									OpWord = null;
								}
								if (SOp != null) {
									DepthStack.OpLeft = SOp;
									SOp = null;
								} else if (Op != null) {
									DepthStack.OpLeft = Op;
									Op = null;
								}
							} else {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										Value = new ValueStack(V, i - 1, Depth, Value);
									}
								}
								var Op = Operator;
								Operator = null;
								var SOp = SetOpLeft;
								SetOpLeft = null;
								if (Value != null) {
									if (SOp != null) { Value.OpLeft = SOp; SOp = null; } else if (Op != null) { Value.OpLeft = Op; Op = null; }
								}
								if (Value != null && Value.Operator == null) Value.Operator = new OperStack('*', i, Depth, null);
								DepthStack = new DepthStack(Char, i, DepthStack);
								if (OpWord != null) {
									DepthStack.OpWord = OpWord;
									OpWord = null;
								}
								if (SOp != null) {
									DepthStack.OpLeft = SOp;
									SOp = null;
								} else if (Op != null) {
									DepthStack.OpLeft = Op;
									Op = null;
								}
							}
							SetOpLeftEnable = false;
							Depth = DepthStack.Depth;
							Start = i + 1;
						}
						break;
					case ')': {
							if (DepthStack != null && DepthStack.IsEnded == false) {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										if (DepthStack.Value != null && DepthStack.Value.Operator == null) DepthStack.Value.Operator = new OperStack('*', i, DepthStack.Depth, null);
										DepthStack.Value = new ValueStack(V, i - 1, Depth, DepthStack.Value);
										var Op = DepthStack.Operator;
										DepthStack.Operator = null;
										var SOp = DepthStack.SetOpLeft;
										DepthStack.SetOpLeft = null;
										if (SOp != null) { DepthStack.Value.OpLeft = SOp; } else if (Op != null) { DepthStack.Value.OpLeft = Op; }
									}
								}
								DepthStack.IsEnded = true;
							} else {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										if (Value != null && Value.Operator == null) Value.Operator = new OperStack('*', i, Depth, null);
										Value = new ValueStack(V, i - 1, Depth, Value);
										var Op = Operator;
										Operator = null;
										var SOp = SetOpLeft;
										SetOpLeft = null;
										if (SOp != null) { Value.OpLeft = SOp; } else if (Op != null) { Value.OpLeft = Op; }
									}
								}
							}
							SetOpLeftEnable = false;
							Start = i + 1;
						}
						break;
					case '%':
					case '/':
					case '*':
					case '-':
					case '+':
					case '!':
					case '?':
					case '=': {
							if (DepthStack != null && DepthStack.IsEnded == false) {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										var Op = DepthStack.Operator;
										DepthStack.Operator = null;
										var SOp = DepthStack.SetOpLeft;
										DepthStack.SetOpLeft = null;
										DepthStack.Value = new ValueStack(V, i - 1, Depth, DepthStack.Value);
										if (SOp != null) {
											DepthStack.Value.OpLeft = SOp;
											SOp = null;
										} else if (Op != null) {
											DepthStack.Value.OpLeft = Op;
											Op = null;
										}
									}
								}
								if (SetOpLeftEnable) {
									DepthStack.SetOpLeft = new OperStack(Char, i, Depth, DepthStack.SetOpLeft);
								} else {
									if (DepthStack.Value != null) {
										DepthStack.Value.Operator = new OperStack(Char, i, Depth, DepthStack.Value.Operator);
									} else {
										DepthStack.Operator = new OperStack(Char, i, Depth, DepthStack.Operator);
									}
								}
							} else {
								if (Start < i) {
									S = Chars.Substring(Start, i - Start);
									V = new BugNum(S);
									if (V.IsVal) {
										var Op = Operator;
										Operator = null;
										var SOp = SetOpLeft;
										SetOpLeft = null;
										Value = new ValueStack(V, i - 1, Depth, Value);
										if (SOp != null) {
											Value.OpLeft = SOp;
											SOp = null;
										} else if (Op != null) {
											Value.OpLeft = Op;
											Op = null;
										}
									}
								}
								if (SetOpLeftEnable) {
									SetOpLeft = new OperStack(Char, i, Depth, SetOpLeft);
								} else {
									if (Value != null) {
										Value.Operator = new OperStack(Char, i, Depth, Value.Operator);
									} else {
										Operator = new OperStack(Char, i, Depth, Operator);
									}
								}
							}
							Start = i + 1;
						}
						break;
					default: {
							if ((Char >= 'a' && Char <= 'z') || (Char >= 'A' && Char <= 'Z')) {
								Char = char.ToLowerInvariant(Char);
								if (OpWord != null) {
									OpWord += Char;
								} else {
									OpWord = Char.ToString();
								}
							} else {
								OpWord = null;
							}
							if (OpWord == "pi") {
								if (DepthStack != null) {
									var Op = DepthStack.Operator;
									DepthStack.Operator = null;
									var SOp = DepthStack.SetOpLeft;
									DepthStack.SetOpLeft = null;
									DepthStack.Value = new ValueStack(BugNum.PI, i - 1, Depth, DepthStack.Value);
									if (SOp != null) {
										DepthStack.Value.OpLeft = SOp;
									} else if (Op != null) {
										DepthStack.Value.OpLeft = Op;
									}
								} else {
									var Op = Operator;
									Operator = null;
									var SOp = SetOpLeft;
									SetOpLeft = null;
									Value = new ValueStack(BugNum.PI, i - 1, Depth, Value);
									if (SOp != null) {
										Value.OpLeft = SOp;
									} else if (Op != null) {
										Value.OpLeft = Op;
									}
								}
								OpWord = null;
							}
						}
						break;
				}
				if (DepthStack != null && DepthStack.IsEnded) {

					var DepthStackValue = DepthStack.Value;
					var Operat = DepthStack.Operator;
					var OpLeft = DepthStack.OpLeft;
					var Word = DepthStack.OpWord;
					DepthStack = DepthStack.Next;
					if (DepthStackValue != null) {
						V = DepthStackValue.End(Word);
						if (OpLeft != null) {
							V = OpLeft.Apply(V);
							OpLeft = null;
						}
						if (V.IsVal) {
							if (DepthStack != null) {
								DepthStack.Value = new ValueStack(V, i - 1, Depth, DepthStack.Value);
							} else {
								Value = new ValueStack(V, i - 1, Depth, Value);
							}
						}
					} else {
						if (Operat != null) {
							if (DepthStack != null) {
								DepthStack.Operator = Operat;
								Operat = null;
							} else {
								Operator = Operat;
							}
						}
					}
					SetOpLeftEnable = false;
				}
			}
			if (DepthStack != null && DepthStack.IsEnded == false) {
				if (Start < Chars.Length) {
					S = Chars.Substring(Start, Chars.Length - Start);
					V = new BugNum(S);
					if (V.IsVal) {
						if (DepthStack.Value != null && DepthStack.Value.Operator == null) DepthStack.Value.Operator = new OperStack('*', 0, 0, DepthStack.Value.Operator);
						var Op = DepthStack.Operator;
						DepthStack.Operator = null;
						var SOp = DepthStack.SetOpLeft;
						DepthStack.SetOpLeft = null;
						DepthStack.Value = new ValueStack(V, Chars.Length - 1, Depth, DepthStack.Value);
						if (SOp != null) { DepthStack.Value.OpLeft = SOp; } else if (Op != null) { DepthStack.Value.OpLeft = Op; }
					}
				}
				DepthStack.IsEnded = true;
			} else {
				if (Start < Chars.Length) {
					S = Chars.Substring(Start, Chars.Length - Start);
					V = new BugNum(S);
					if (V.IsVal) {
						if (Value != null && Value.Operator == null) Value.Operator = new OperStack('*', 0, 0, Value.Operator);
						var Op = Operator;
						Operator = null;
						var SOp = SetOpLeft;
						SetOpLeft = null;
						Value = new ValueStack(V, Chars.Length - 1, Depth, Value);
						if (SOp != null) { Value.OpLeft = SOp; } else if (Op != null) { Value.OpLeft = Op; }
					}
				}
			}
			while (DepthStack != null) {
				var DepthStackValue = DepthStack.Value;
				var Word = DepthStack.OpWord;
				var Operat = DepthStack.Operator;
				var OpLeft = DepthStack.OpLeft;
				DepthStack = DepthStack.Next;
				if (DepthStackValue != null) {
					V = DepthStackValue.End(Word);

					if (OpLeft != null) {
						V = OpLeft.Apply(V);
						OpLeft = null;
					}
					if (V.IsVal) {
						if (DepthStack != null) {
							DepthStack.Value = new ValueStack(V, 0, Depth, DepthStack.Value);
							DepthStack.Value.OpLeft = OpLeft;
						} else {
							Value = new ValueStack(V, 0, Depth, Value);
							Value.OpLeft = OpLeft;
						}
					}
				} else {
					if (Operat != null) {
						if (DepthStack != null) {
							DepthStack.Operator = Operat;
							Operat = null;
						} else {
							Operator = Operat;
						}
					}
				}
			}
			if (Value != null)
				TextResult.Text = Value.End(null).ToString();
			else TextResult.Text = "";
		}
		#endregion
		#region #method# N_Enter(sender, e) 
		private void N_Enter(object sender, RoutedEventArgs e) {
			TextValue.Focus();
		}
		#endregion
		#region #method# CBackspace_Click(sender, e) 
		private void CBackspace_Click(object sender, RoutedEventArgs e) {
			var D = sender as Button;
			var I = TextValue.CaretIndex;
			var C = TextValue.SelectionLength;
			var V = TextValue.Text;
			if (C > 0) {
				I = TextValue.SelectionStart;
				TextValue.Text = V.Remove(I, C);
				TextValue.CaretIndex = I;
			} else {
				if (I > 0) {
					TextValue.Text = V.Remove(I - 1, 1);
					TextValue.CaretIndex = I - 1;
				}
			}
		}
		#endregion
		#region #method# N_Click(sender, e) 
		private void N_Click(object sender, RoutedEventArgs e) {
			var D = sender as Button;
			var I = TextValue.CaretIndex;
			var C = TextValue.SelectionLength;
			var V = TextValue.Text;
			if (C > 0) {
				I = TextValue.SelectionStart;
				V = V.Remove(I, C);
				TextValue.Text = V.Insert(I, D.Text);
				TextValue.CaretIndex = I + D.Text.Length;
			} else {
				TextValue.Text = V.Insert(I, D.Text);
				TextValue.CaretIndex = I + D.Text.Length;
			}
		}
		#endregion
		#region #method# Label_Click(sender, e) 
		private void Label_Click(object sender, RoutedEventArgs e) {
			this.Visibility = Visibility.Collapsed;
		}
		#endregion
		#region #method# Parent_Lowef(sender, e) 
		private void Parent_Lowef(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextResult.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}
		#endregion
		#region #method# Parent_Sizef(sender, e) 
		private void Parent_Sizef(object sender, RoutedEventArgs e) {
			TextValue.FontSize = Calculator.Sizef;
			TextResult.FontSize = Calculator.Sizef;
		}
		#endregion
		#region #method# Parent_Weigf(sender, e) 
		private void Parent_Weigf(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextResult.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}
		#endregion
	}
	#endregion
	#region #class# TextBodrer 
	public class TextBodrer : System.Windows.Controls.Border {
		protected override void OnMouseDown(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseButtonEventArgs e) {
			e.Handled = true;
			base.OnMouseUp(e);
		}
		public static System.Windows.Media.Color BgColor = System.Windows.Media.Color.FromArgb(255, 0x18, 0x18, 0x18);
		public static System.Windows.Media.Color FgColor = System.Windows.Media.Color.FromArgb(255, 0xef, 0xef, 0xef);
		public readonly System.Windows.Controls.TextBox TextValue = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		public readonly System.Windows.Controls.TextBox TextResult = new System.Windows.Controls.TextBox() {
			VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
			Background = Colors.Background,
			Foreground = Colors.Foreground,
			AcceptsTab = true,
			AcceptsReturn = true,
			TextWrapping = System.Windows.TextWrapping.Wrap,
			Margin = new System.Windows.Thickness(2),
			FontSize = Calculator.Sizef,
			FontFamily = Calculator.GetOnce(Calculator.Weigf)
		};
		public readonly System.Windows.Controls.Grid GridMain = new System.Windows.Controls.Grid() {

		};
		public readonly System.Windows.Controls.WrapPanel PanelMain = new System.Windows.Controls.WrapPanel() {
			Orientation = System.Windows.Controls.Orientation.Horizontal,
			Margin = new System.Windows.Thickness(0, 0, 8, 8),
		};
		public readonly new MainWindow Parent;
		public readonly Button Label;
		public readonly Button ButtonT = new Button("Найти все делители", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public TextBodrer(MainWindow Parent, string Name) {
			this.Parent = Parent;
			this.Label = new Button(Name, Font277.Instance, 20) { Margin = new Thickness(8, 8, 0, 0) };
			Parent.Weigf += Parent_Weigf;
			Parent.Sizef += Parent_Sizef;
			Parent.Lowef += Parent_Lowef;
			this.BorderThickness = new System.Windows.Thickness(2, 2, 2, 2);
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			GridMain.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
			this.Child = GridMain;
			GridMain.Children.Add(PanelMain);
			GridMain.Children.Add(TextValue);
			GridMain.Children.Add(TextResult);
			System.Windows.Controls.Grid.SetRow(PanelMain, 0);
			System.Windows.Controls.Grid.SetRow(TextValue, 1);
			System.Windows.Controls.Grid.SetRow(TextResult, 2);
			this.BorderBrush = new System.Windows.Media.SolidColorBrush(FgColor);
			this.Label.Click += Label_Click;
			PanelMain.Children.Add(Label);
			PanelMain.Children.Add(ButtonT);
			ButtonT.Click += ButtonT_Click;
		}

		private void Label_Click(object sender, RoutedEventArgs e) {
			this.Visibility = Visibility.Collapsed;
		}

		private void ButtonT_Click(object sender, RoutedEventArgs e) {
			var Value = new BugInt(TextValue.Text);
			if (Value < 0) Value = -Value;
			var Count = 0;
			Map.ULong<BugInt> List = null;
			for (var I = 2; I < 1000000 && I < Value; I++) {
				var D = BugInt.DivMod(Value, I, out var M);
				if (M == 0) {
					if (Map.ULong<BugInt>.Add(ref List, (ulong)I, I)) {
						Count++;
					}
				}
			}
			if (Count > 0) {
				for (var Item = List.Base; Item != null; Item = Item.Above) {
					var V = Item.Value;
					for (var Item2 = List.Base; Item2 != null; Item2 = Item2.Above) {
						var V2 = Item2.Value * V;
						if (V2 < Value && V2 <= ulong.MaxValue) {
							var D = BugInt.DivMod(Value, V2, out var M);
							if (M == 0) {
								if (Map.ULong<BugInt>.Add(ref List, (ulong)V2, V2)) {
									Count++;
								}
							}
						}
					}
				}
			}
			var R = "Всего найдено: " + Count.ToString() + "\r\n";
			if (Count > 0) {
				for (var Item = List.Base; Item != null; Item = Item.Above) {
					var V = Item.Value;
					if (V < Value) {
						var D = BugInt.DivMod(Value, V, out var M);
						R += Value.ToString() + " / " + V.ToString() + " = " + D.ToString() + "\r\n";
					}
				}
			}
			TextResult.Text = R;
		}

		private void Parent_Lowef(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextResult.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}
		private void Parent_Sizef(object sender, RoutedEventArgs e) {
			TextValue.FontSize = Calculator.Sizef;
			TextResult.FontSize = Calculator.Sizef;
		}
		private void Parent_Weigf(object sender, RoutedEventArgs e) {
			TextValue.FontFamily = Calculator.GetOnce(Calculator.Weigf);
			TextResult.FontFamily = Calculator.GetOnce(Calculator.Weigf);
		}
	}
	#endregion
}