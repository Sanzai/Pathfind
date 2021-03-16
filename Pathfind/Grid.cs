using System.Collections.Generic;

namespace FranciscoSarabia {

    namespace Pathfind {

        public class Grid {

            public readonly Node[,] grid;

            public Grid() : this(1, 1) { }

            public Grid(int width, int height) {

                grid = new Node[width, height];

                for (int i = 0; i < width; i++) {

                    for (int j = 0; j < height; j++) {

                        grid[i, j] = new Node(i, j);

                    }

                }

            }

            public Grid(Node[,] grid) {

                this.grid = grid;

            }

            public bool IsInGrid(Node node) {

                return !OutOfBounds(node.Position) && grid[node.Position.x, node.Position.y] == node;

            }

            /// <summary>
            /// Return a list with the neighbouring nodes of the node provided. Looks at the 8 direcctions around the node
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public List<Node> Neighbours(Node node) {

                List<Node> neighbours = new List<Node>();
                int positionX, positionY;

                if (IsInGrid(node)) {

                    for (int i = -1; i <= 1; i++) {

                        positionX = node.Position.x + i;

                        for (int j = -1; j <= 1; j++) {

                            positionY = node.Position.y + j;

                            if (!OutOfBounds(positionX, positionY) && grid[positionX, positionY] != node) {

                                neighbours.Add(grid[positionX, positionY]);

                            }

                        }

                    }

                }

                return neighbours;

            }

            private bool OutOfBounds(Position pos) {

                return OutOfBounds(pos.x, pos.y);

            }

            private bool OutOfBounds(int x, int y) {

                return x < 0 || x >= grid.GetLength(0) || y < 0 || y >= grid.GetLength(1);

            }

        }

    }

}