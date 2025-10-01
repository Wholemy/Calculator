using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
namespace Wholemy {
	#region #class# Calculator 
	public class Calculator : System.Windows.Application {

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
		public readonly NumberBodrer C;
		public readonly NumberBodrer D;
		public readonly NumberBodrer E;
		public readonly NumberBodrer F;
		public readonly NumberBodrer G;
		public readonly NumberBodrer H;
		public readonly GlobalFunctionBodrer Func;
		public readonly GlobalSettingsBodrer Glob;
		public MainWindow() {
			A = new NumberBodrer(this, "A");
			B = new NumberBodrer(this, "B");
			C = new NumberBodrer(this, "C");
			D = new NumberBodrer(this, "D");
			E = new NumberBodrer(this, "E");
			F = new NumberBodrer(this, "F");
			G = new NumberBodrer(this, "G");
			H = new NumberBodrer(this, "H");
			Func = new GlobalFunctionBodrer(this);
			Glob = new GlobalSettingsBodrer(this);
			this.WindowState = System.Windows.WindowState.Normal;
			this.Title = "Большой калькулятор";
			Background = Colors.Background;
			Foreground = Colors.Foreground;
			this.Content = ScrollViewer;
			ScrollViewer.Content = VStack;
			VStack.Children.Add(Glob);
			VStack.Children.Add(Func);
			VStack.Children.Add(A);
			VStack.Children.Add(B);
			VStack.Children.Add(C);
			VStack.Children.Add(D);
			VStack.Children.Add(E);
			VStack.Children.Add(F);
			VStack.Children.Add(G);
			VStack.Children.Add(H);
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
			this.BorderThickness = new System.Windows.Thickness(2, 2, 2, 2);
			this.BorderBrush = Colors.Foreground;
			this.Child = PanelMain;
			var LabelDepth = new System.Windows.Controls.Label() { Content = "Макс дроби", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
			var LabelChars = new System.Windows.Controls.Label() { Content = "Макс дроби в результате", Foreground = new System.Windows.Media.SolidColorBrush(FgColor), VerticalAlignment = System.Windows.VerticalAlignment.Center, HorizontalAlignment = System.Windows.HorizontalAlignment.Right };
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
		public readonly Button ButtonAaddBequC = new Button("A + B = C", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAsubBequC = new Button("A - B = C", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAmulBequC = new Button("A * B = C", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAdivBequC = new Button("A / B = C", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAdivBequCmodD = new Button("A / B = C % D", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAsqrtC = new Button("C = Sqrt(A)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAsinC = new Button("C = Sin(A)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAcosC = new Button("C = Cos(A)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAtanC = new Button("C = Tan(A)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly Button ButtonAatanC = new Button("C = Atan(A)", Font277.Instance, 20) {
			Margin = new System.Windows.Thickness(8, 8, 0, 0),
		};
		public readonly new MainWindow Parent;
		public GlobalFunctionBodrer(MainWindow Parent) {
			this.Parent = Parent;
			this.Child = PanelMain;
			ButtonAaddBequC.Click += ButtonAaddBequC_Click;
			PanelMain.Children.Add(ButtonAaddBequC);
			ButtonAsubBequC.Click += ButtonAsubBequC_Click;
			PanelMain.Children.Add(ButtonAsubBequC);
			ButtonAmulBequC.Click += ButtonAmulBequC_Click;
			PanelMain.Children.Add(ButtonAmulBequC);
			ButtonAdivBequC.Click += ButtonAdivBequC_Click;
			PanelMain.Children.Add(ButtonAdivBequC);
			ButtonAdivBequCmodD.Click += ButtonAdivBequCmodD_Click;
			PanelMain.Children.Add(ButtonAdivBequCmodD);
			ButtonAsqrtC.Click += ButtonAsqrtC_Click;
			PanelMain.Children.Add(ButtonAsqrtC);
			ButtonAsinC.Click += ButtonAsinC_Click;
			PanelMain.Children.Add(ButtonAsinC);
			ButtonAcosC.Click += ButtonAcosC_Click;
			PanelMain.Children.Add(ButtonAcosC);
			ButtonAtanC.Click += ButtonAtanC_Click;
			PanelMain.Children.Add(ButtonAtanC);
			ButtonAatanC.Click += ButtonAatanC_Click;
			PanelMain.Children.Add(ButtonAatanC);
		}

		private void ButtonAatanC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = BugNum.TAtanOfTan(this.Parent.A.Number);
			} catch { }
		}

		private void ButtonAtanC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = BugNum.TTan(this.Parent.A.Number);
			} catch { }
		}

		private void ButtonAcosC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = BugNum.TCos(this.Parent.A.Number);
			} catch { }
		}

		private void ButtonAsinC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = BugNum.TSin(this.Parent.A.Number);
			} catch { }
		}

		private void ButtonAsqrtC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = BugNum.Sqrt(this.Parent.A.Number);
			} catch { }
		}

		private void ButtonAdivBequCmodD_Click(object sender, RoutedEventArgs e) {
			try {
				var A = this.Parent.A.Number;
				var B = this.Parent.B.Number;
				this.Parent.C.Number = BugInt.DivMod(A.Numer / A.Venom, B.Numer / B.Venom, out var M);
				this.Parent.D.Number = M;
			} catch { }
		}

		private void ButtonAdivBequC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = this.Parent.A.Number / this.Parent.B.Number;
			} catch { }
		}

		private void ButtonAmulBequC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = this.Parent.A.Number * this.Parent.B.Number;
			} catch { }
		}

		private void ButtonAsubBequC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = this.Parent.A.Number - this.Parent.B.Number;
			} catch { }
		}

		private void ButtonAaddBequC_Click(object sender, RoutedEventArgs e) {
			try {
				this.Parent.C.Number = this.Parent.A.Number + this.Parent.B.Number;
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
		public readonly Label NumberLabel;
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
			NumberLabel = new Label(Parent.NumberName, Font277.Instance, 20) { Margin = new Thickness(8) };
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
}