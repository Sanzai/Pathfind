using System;
using UnityEngine;

namespace FranciscoSarabia {

    namespace Pathfind {

        [Serializable]
        public struct Position : IEquatable<Position> {

            public int x, y;

            public Position(int x, int y) {

                this.x = x;
                this.y = y;

            }

            public static Position operator +(Position a, Position b) {

                return new Position(a.x + b.x, a.y + b.y);

            }

            public static Position operator -(Position a, Position b) {

                return new Position(a.x - b.x, a.y - b.y);

            }

            public static bool operator ==(Position a, Position b) {

                return (a.x == b.x && a.y == b.y);

            }

            public static bool operator !=(Position a, Position b) {

                return !(a == b);

            }

            public static implicit operator Vector2(Position p) {

                return new Vector2(p.x, p.y);

            }

            public static implicit operator Vector3(Position p) {

                return new Vector3(p.x, p.y, 0);

            }

            public override bool Equals(object obj) {

                if (obj is Position) {

                    Position p = (Position)obj;
                    return x == p.x && y == p.y;

                }

                return false;

            }

            public bool Equals(Position p) {

                return x == p.x && y == p.y;

            }

            public override int GetHashCode() {

                return x ^ y;

            }

            public override string ToString() {

                return $"[{x}, {y}]";

            }

        }

    }

}