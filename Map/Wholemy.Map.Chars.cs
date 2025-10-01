namespace Wholemy {
	public static partial class Map {
		#region #trace# 
#if TRACE
		[System.Diagnostics.DebuggerDisplay("Map.C Count={Count}")]
#endif
		#endregion
		public class Chars<T> {
			#region #private# #class# Val & Led 
			public class Val {
				private readonly object chars;
				public readonly int index;
				public readonly int count;
				public T value;
				public Map.Int<Led> ileds;
				#region #new# (chars, index, count, value) 
				public Val(string chars, int index, int count, T value) {
					this.chars = chars;
					this.index = index;
					this.count = count;
					this.value = value;
					this.ileds = null;
				}
				#endregion
				#region #new# (chars, index, count, value) 
				public Val(char[] chars, int index, int count, T value) {
					this.chars = chars;
					this.index = index;
					this.count = count;
					this.value = value;
					this.ileds = null;
				}
				#endregion
				//#region #new# (chars, index, count, value) 
				//public Val(char* chars, int index, int count, T value) {
				//	this.chars = (System.IntPtr)chars;
				//	this.index = index;
				//	this.count = count;
				//	this.value = value;
				//	this.ileds = null;
				//}
				//#endregion
				#region #this#[I] 
				public char this[int I] {
					get {
						if (chars is string)
							return ((string)chars)[index + I];
						if (chars is char[])
							return ((char[])chars)[index + I];
						throw new System.ArgumentOutOfRangeException();
						//return ((char*)(System.IntPtr)chars)[index + I];
					}
				}
				#endregion
			}
			public class Led {
				public Map.Int<Val> ivals;
				#region #new# (chars, index, count, value, Index) 
				public Led(string chars, int index, int count, T value, int Index = 0) {
					Map.Int<Val>.Add(ref this.ivals, chars[index + Index], new Val(chars, index, count, value));
				}
				#endregion
				#region #new# (chars, index, count, value, Index) 
				public Led(char[] chars, int index, int count, T value, int Index = 0) {
					Map.Int<Val>.Add(ref this.ivals, chars[index + Index], new Val(chars, index, count, value));
				}
				#endregion
				#region #new# (chars, index, count, value, Index) 
				//public Led(char* chars, int index, int count, T value, int Index = 0) {
				//	Map.Int<Val>.Add(ref this.ivals, chars[index + Index], new Val(chars, index, count, value));
				//}
				#endregion
			}
			#endregion
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public T empty;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public T nully;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			private int count;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			public int Count => this.count;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			private Map.Int<Led> ileds;
			#region #method# Add 
			public bool Add(T value, string chars, int index = 0, int count = 0) {
				if (value == null)
					throw new System.ArgumentNullException(nameof(value));
				if (chars == null) {
					if (this.nully != null)
						return false;
					this.nully = value;
					this.count++;
					return true;
				}
				if (count == 0) count = chars.Length - index;
				if (count == 0) {
					if (this.empty != null)
						return false;
					this.empty = value;
					this.count++;
					return true;
				}
				var star = Map.GetV(ref this.ileds, count);
				if (star != null) {
					var Index = 0;
					var Char = chars[index + Index];
					var valu = Map.GetV(ref star.ivals, Char);
					if (valu != null) {
						while (Index < count) {
							Char = chars[index + Index];
							if (valu[Index] != Char) {
								star = Map.GetV(ref valu.ileds, Index);
								if (star != null) {
									valu = Map.GetV(ref star.ivals, Char);
									if (valu == null) {
										if (Map.Int<Val>.Add(ref star.ivals, Char, new Val(chars, index, count, value))) {
											this.count++;
											return true;
										}
									}
								} else {
									if (Map.Int<Led>.Add(ref valu.ileds, Index, new Led(chars, index, count, value, Index))) {
										this.count++;
										return true;
									}
								}
							}
							Index++;
						}
					} else {
						if (Map.Int<Val>.Add(ref star.ivals, Char, new Val(chars, index, count, value))) {
							this.count++;
							return true;
						}
					}
				} else {
					if (Map.Int<Led>.Add(ref this.ileds, count, new Led(chars, index, count, value))) {
						this.count++;
						return true;
					}
				}
				return false;
			}
			#endregion
			#region #method# Add 
			public bool Add(T value, char[] chars, int index = 0, int count = 0) {
				if (value == null)
					throw new System.ArgumentNullException(nameof(value));
				if (chars == null) {
					if (this.nully != null)
						return false;
					this.nully = value;
					this.count++;
					return true;
				}
				if (count == 0) count = chars.Length - index;
				if (count == 0) {
					if (this.empty != null)
						return false;
					this.empty = value;
					this.count++;
					return true;
				}
				var star = Map.GetV(ref this.ileds, count);
				if (star != null) {
					var Index = 0;
					var Char = chars[index + Index];
					var valu = Map.GetV(ref star.ivals, Char);
					if (valu != null) {
						while (Index < count) {
							Char = chars[index + Index];
							if (valu[Index] != Char) {
								star = Map.GetV(ref valu.ileds, Index);
								if (star != null) {
									valu = Map.GetV(ref star.ivals, Char);
									if (valu == null) {
										if (Map.Int<Val>.Add(ref star.ivals, Char, new Val(chars, index, count, value))) {
											this.count++;
											return true;
										}
									}
								} else {
									if (Map.Int<Led>.Add(ref valu.ileds, Index, new Led(chars, index, count, value, Index))) {
										this.count++;
										return true;
									}
								}
							}
							Index++;
						}
					} else {
						if (Map.Int<Val>.Add(ref star.ivals, Char, new Val(chars, index, count, value))) {
							this.count++;
							return true;
						}
					}
				} else {
					if (Map.Int<Led>.Add(ref this.ileds, count, new Led(chars, index, count, value))) {
						this.count++;
						return true;
					}
				}
				return false;
			}
			#endregion
			#region #method# Get 
			public T Get(string chars, int index = 0, int count = 0) {
				if (chars == null) return this.nully;
				if (count == 0) count = chars.Length - index;
				if (count == 0) return this.empty;
				var star = Map.GetV(ref this.ileds, count);
				if (star != null) {
					var Index = 0;
					var Char = chars[index + Index];
					var valu = Map.GetV(ref star.ivals, Char);
					while (valu != null && Index < count) {
						Char = chars[index + Index];
						if (valu[Index] != Char) {
							star = Map.GetV(ref valu.ileds, Index);
							if (star != null) valu = Map.GetV(ref star.ivals, Char); else valu = null;
						}
						Index++;
					}
					if (valu != null) return valu.value;
				}
				return default(T);
			}
			#endregion
			#region #method# Get 
			public T Get(char[] chars, int index = 0, int count = 0) {
				if (chars == null) return this.nully;
				if (count == 0) count = chars.Length - index;
				if (count == 0) return this.empty;
				var star = Map.GetV(ref this.ileds, count);
				if (star != null) {
					var Index = 0;
					var Char = chars[index + Index];
					var valu = Map.GetV(ref star.ivals, Char);
					while (valu != null && Index < count) {
						Char = chars[index + Index];
						if (valu[Index] != Char) {
							star = Map.GetV(ref valu.ileds, Index);
							if (star != null) valu = Map.GetV(ref star.ivals, Char); else valu = null;
						}
						Index++;
					}
					if (valu != null) return valu.value;
				}
				return default(T);
			}
			#endregion
		}
	}
}