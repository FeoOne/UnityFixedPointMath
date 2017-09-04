using System;
using UnityEngine;

namespace Mathfp
{
	public struct FixedPointVector2 : IEquatable<FixedPointVector2>, IComparable<FixedPointVector2>
	{
		public FixedPoint X;
		public FixedPoint Y;

		public static readonly FixedPointVector2 Zero = new FixedPointVector2(FixedPoint.Zero, FixedPoint.Zero);
		public static readonly FixedPointVector2 Identity = new FixedPointVector2(FixedPoint.One, FixedPoint.Zero);

		public FixedPoint Point {
			get { return unchecked(X + Y); }
		}

		public FixedPointVector2(FixedPoint x, FixedPoint y)
		{
			X = x;
			Y = y;
		}

		public static FixedPoint Dot(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return a.X * b.X + a.Y * b.Y;
			}
		}

		public static FixedPointVector2 Project(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return b * (a * b) / (b * b);
			}
		}

		public static FixedPointVector2 operator -(FixedPointVector2 v)
		{
			return new FixedPointVector2(-v.X, -v.Y);
		}

		public static FixedPointVector2 operator +(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return new FixedPointVector2(a.X + b.X, a.Y + b.Y);
			}
		}

		public static FixedPointVector2 operator -(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return new FixedPointVector2(a.X - b.X, a.Y - b.Y);
			}
		}

		public static FixedPointVector2 operator *(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return new FixedPointVector2(a.X * b.X, a.Y * b.Y);
			}
		}

		public static FixedPointVector2 operator /(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return new FixedPointVector2(a.X / b.X, a.Y / b.Y);
			}
		}

		public static FixedPointVector2 operator *(FixedPointVector2 a, FixedPoint b)
		{
			unchecked {
				return new FixedPointVector2(a.X * b, a.Y * b);
			}
		}

		public static FixedPointVector2 operator /(FixedPointVector2 a, FixedPoint b)
		{
			unchecked {
				return new FixedPointVector2(a.X / b, a.Y / b);
			}
		}

		public static bool operator ==(FixedPointVector2 a, FixedPointVector2 b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(FixedPointVector2 a, FixedPointVector2 b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

		public static bool operator ==(FixedPointVector2 a, FixedPoint n)
		{
			return a.X == n && a.Y == n;
		}

		public static bool operator !=(FixedPointVector2 a, FixedPoint n)
		{
			return a.X != n || a.Y != n;
		}

		public static bool operator >(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return (a.X - b.X) + (a.Y - b.Y) > 0;
			}
		}

		public static bool operator <(FixedPointVector2 a, FixedPointVector2 b)
		{
			unchecked {
				return (b.X - a.X) + (b.Y - a.Y) > 0;
			}
		}

		public bool Equals(FixedPointVector2 other)
		{
			return this == other;
		}

		public FixedPoint Magnitude {
			get {
				var m2 = Magnitude2;
				return (m2 == 0) ? 0 : m2.Sqrt();
			}
		}

		public FixedPoint Magnitude2 {
			get {
				return unchecked(X * X + Y * Y);
			}
		}

		public FixedPointVector2 Normalize()
		{
			FixedPointVector2 result = new FixedPointVector2(0, 0);
			var magnitude = Magnitude;
			if (magnitude != 0) {
				unchecked {
					result.X = X / magnitude;
					result.Y = Y / magnitude;
				}
			}
			return result;
		}

		public void NormalizeThis()
		{
			var magnitude = Magnitude;
			if (magnitude != 0) {
				unchecked {
					X = X / magnitude;
					Y = Y / magnitude;
				}
			}
		}

		public FixedPointVector2 Abs {
			get {
				return new FixedPointVector2(FixedPoint.Abs(X), FixedPoint.Abs(Y));
			}
		}

		public static explicit operator FixedPointVector2(Vector2 v)
		{
			return new FixedPointVector2((FixedPoint)v.x, (FixedPoint)v.y);
		}

		public static explicit operator FixedPointVector2(Vector3 v)
		{
			return new FixedPointVector2((FixedPoint)v.x, (FixedPoint)v.y);
		}

		public static implicit operator Vector3(FixedPointVector2 v)
		{
			return new Vector3(v.X.ToFloat(), v.Y.ToFloat(), 0.0f);
		}

		public static implicit operator Vector2(FixedPointVector2 v)
		{
			return new Vector2(v.X.ToFloat(), v.Y.ToFloat());
		}

		public static implicit operator FixedPointVector3(FixedPointVector2 v)
		{
			return new FixedPointVector3(v.X, v.Y, 0);
		}

		public override bool Equals(object obj)
		{
			return obj is FixedPointVector2 && this == (FixedPointVector2)obj;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public int CompareTo(FixedPointVector2 other)
		{
			return Point.CompareTo(other.Point);
		}

		public static FixedPoint Distance(FixedPointVector2 v1, FixedPointVector2 v2)
		{
			unchecked {
				FixedPoint x = v1.X - v2.X;
				FixedPoint y = v1.Y - v2.Y;
				FixedPoint f = x * x + y * y;
				return f.Sqrt();
			}
		}

		public static FixedPoint DistanceSquared(FixedPointVector2 v1, FixedPointVector2 v2)
		{
			unchecked {
				FixedPoint x = v1.X - v2.X;
				FixedPoint y = v1.Y - v2.Y;
				return x * x + y * y;
			}
		}

		public static FixedPoint Cross(FixedPointVector2 v1, FixedPointVector2 v2)
		{
			unchecked {
				return v1.X * v2.Y - v1.Y * v2.X;
			}
		}

		public FixedPointVector2 Rotate(FixedPoint angle)
		{
			unchecked {
				FixedPoint cos = angle.Cos();
				FixedPoint sin = angle.Sin();

				return new FixedPointVector2(X * cos - Y * sin, X * sin + Y * cos);
			}
		}

		public override string ToString()
		{
			return "(" + X.ToString() + ", " + Y.ToString() + ")";
		}

		public FixedPointVector2 RotateLeft90Deg()
		{
			return new FixedPointVector2(-Y, X);
		}

		public FixedPointVector2 RotateRight90Deg()
		{
			return new FixedPointVector2(Y, -X);
		}

		public FixedPoint GetLength()
		{
			unchecked {
				FixedPoint result = X * X + Y * Y;
				if (result > FixedPoint.Zero) {
					result = result.Sqrt();
				}
				return result;
			}
		}

		public FixedPoint GetLengthSquared()
		{
			unchecked {
				return (X * X + Y * Y);
			}
		}

		public static FixedPoint GetAngleBetweenVectors(FixedPointVector2 v1, FixedPointVector2 v2)
		{
			return FixedPoint.Atan2(
				v1.X * v2.Y - v2.X * v1.Y,
				v1.X * v2.X + v1.Y * v2.Y
			);
		}

		public static bool FastInRangeCheck(FixedPointVector2 v1, FixedPointVector2 v2, FixedPoint dist)
		{
			return FixedPoint.Abs(v1.Y - v2.Y) < dist &&
			       FixedPoint.Abs(v1.X - v2.X) < dist;
		}

		public static FixedPointVector2 Truncate(FixedPointVector2 v, FixedPoint length)
		{
			if (v.GetLengthSquared() > length * length) {
				v = v.Normalize() * length;
			}
			return v;
		}
	}
}
