using System;

namespace FranciscoSarabia {

    namespace Pathfind {

        public class Node : IEquatable<Node> {

            private int distance;
            private float heuristic;
            private Node previous;
            private Position position;

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

            public Position Position {
                get => position;
                set => position = value;
            }

            #endregion

            public Node() : this(0, 0) { }

            public Node(int x, int y) {


                ResetPathfindingInThisNode();
                position = new Position(x, y);

            }

            public void ResetPathfindingInThisNode() {

                distance = int.MaxValue;
                previous = null;
                heuristic = int.MaxValue;

            }

            public static bool operator == (Node a, Node b) {

                if (a is null || b is null) {

                    return (a is null && b is null);

                }

                return a.position == b.position;

            }

            public static bool operator !=(Node a, Node b) {

                return !(a == b);

            }

            public override bool Equals(object obj) {

                if (obj is Node) {

                    Node node = (Node)obj;

                    return position == node.position;

                }

                return false;

            }

            public bool Equals(Node other) {

                return position == other.position;

            }

            public override int GetHashCode() {

                return position.GetHashCode();

            }

        }

    }

}
