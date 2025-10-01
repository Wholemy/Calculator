namespace Wholemy {
	public static partial class Map {
		#region #trace# 
#if TRACE
		[System.Diagnostics.DebuggerDisplay("Map.B Count={Count}")]
#endif
		#endregion
		public class Bytes<T> {
			#region #private# #class# Valu & Star 
			private class Valu {
				private readonly byte[] bytes;
				public readonly int index;
				public readonly int count;
				public T value;
				public Map.Int<Star> stars;
				#region #new# (bytes, index, count, value) 
				public Valu(byte[] bytes, int index, int count, T value) {
					this.bytes = bytes;
					this.index = index;
					this.count = count;
					this.value = value;
					this.stars = null;
				}
				#endregion
				#region #this#[I] 
				public byte this[int I] {
					get => bytes[index + I];
				}
				#endregion
			}
			private class Star {
				public Map.Int<Valu> valus;
				#region #new# (bytes, index, count, value, Index) 
				public Star(byte[] bytes, int index, int count, T value, int Index = 0) {
					Map.Int<Valu>.Add(ref this.valus, bytes[index + Index], new Valu(bytes, index, count, value));
				}
				#endregion
			}
			#endregion
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
			public T nully;
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
			public int Count => this.count;
			#region #invisible# 
#if TRACE
			[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#endif
			#endregion
			private Map.Int<Star> stars;
			#region #method# Add 
			public bool Add(T value, byte[] bytes, int index = 0, int count = 0) {
				if (value == null)
					throw new System.ArgumentNullException(nameof(value));
				if (bytes == null) {
					if (this.nully != null)
						return false;
					this.nully = value;
					this.count++;
					return true;
				}
				if (count == 0) count = bytes.Length - index;
				if (count == 0) {
					if (this.empty != null)
						return false;
					this.empty = value;
					this.count++;
					return true;
				}
				var star = Map.GetV(ref this.stars, count);
				if (star != null) {
					var Index = 0;
					var Byte = bytes[index + Index];
					var valu = Map.GetV(ref star.valus, Byte);
					if (valu != null) {
						while (Index < count) {
							Byte = bytes[index + Index];
							if (valu[Index] != Byte) {
								star = Map.GetV(ref valu.stars, Index);
								if (star != null) {
									valu = Map.GetV(ref star.valus, Byte);
									if (valu == null) {
										if (Map.Int<Valu>.Add(ref star.valus, Byte, new Valu(bytes, index, count, value))) {
											this.count++;
											return true;
										}
									}
								} else {
									if (Map.Int<Star>.Add(ref valu.stars, Index, new Star(bytes, index, count, value, Index))) {
										this.count++;
										return true;
									}
								}
							}
							Index++;
						}
					} else {
						if (Map.Int<Valu>.Add(ref star.valus, Byte, new Valu(bytes, index, count, value))) {
							this.count++;
							return true;
						}
					}
				} else {
					if (Map.Int<Star>.Add(ref this.stars, count, new Star(bytes, index, count, value))) {
						this.count++;
						return true;
					}
				}
				return false;
			}
			#endregion
			#region #method# Get 
			public T Get(byte[] bytes, int index = 0, int count = 0) {
				if (bytes == null) return this.nully;
				if (count == 0) count = bytes.Length - index;
				if (count == 0) return this.empty;
				var star = Map.GetV(ref this.stars, count);
				if (star != null) {
					var Index = 0;
					var Byte = bytes[Index];
					var valu = Map.GetV(ref star.valus, Byte);
					while (valu != null && Index < count) {
						Byte = bytes[Index];
						if (valu[Index] != Byte) {
							star = Map.GetV(ref valu.stars, Index);
							if (star != null) valu = Map.GetV(ref star.valus, Byte); else valu = null;
						}
						Index++;
					}
					if (valu != null) return valu.value;
				}
				return default;
			}
			#endregion
		}
	}
}