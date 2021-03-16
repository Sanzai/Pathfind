using System;
using UnityEngine;

namespace FranciscoSarabia {

    namespace Pathfind {

        public class Node : IEquatable<Node> {

            private int distance;
            private float heuristic;
            private Node previous;
            private int x, y;

            #region Properties

            public int Distance {

                get => distance;
                set => distance = value;

            }

            public float Heuristic {

                get => heuristic;
                set => heuristic = value;

            }

            public Node Previous {

                get => previous;
                set => previous = value;

            }

            public int X {
                get => x;
                set => x = value;
            }

            public int Y {
                get => y;
                set => y = value;
            }

            #endregion

            public Node() : this(0, 0) { }

            public Node(int x, int y) {

                ResetPathfindingInThisNode();
                this.x = x;
                this.y = y;

            }

            public void ResetPathfindingInThisNode() {

                distance = int.MaxValue;
                previous = null;
                heuristic = int.MaxValue;

            }

            public static implicit operator Vector2(Node node) {

                return new Vector2(node.x, node.y);

            }

            public static implicit operator Vector3(Node node) {

                return new Vector3(node.x, node.y, 0);

            }

            public static bool operator ==(Node a, Node b) {

                if (a is null || b is null) {

                    return (a is null && b is null);

                }

                return (a.x == b.x && a.y == b.y);

            }

            public static bool operator !=(Node a, Node b) {

                return !(a == b);

            }

            public override bool Equals(object obj) {

                if (obj is Node) {

                    Node node = (Node)obj;

                    return x == node.x && y == node.y;

                }

                return false;

            }

            public bool Equals(Node node) {

                return x == node.x && y == node.y;

            }

            public override int GetHashCode() {

                return x ^ y;

            }

            public override string ToString() {

                return $"Node [{x}, {y}]";

            }

        }

    }

}
