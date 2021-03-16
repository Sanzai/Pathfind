using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using UnityEngine;

namespace FranciscoSarabia {

    namespace Pathfind {

        public static class PathFind {

            /// <summary>
            /// A* pathfinding algorithm that returns a List<Node> with the path
            /// </summary>
            /// <param name="startNode">Node from where to start the algorithm</param>
            /// <param name="endNode">Node to find the path to</param>
            /// <param name="tileEvaluationFunction">Function used to evaluate the tiles to check in the algorithm</param>
            /// <returns></returns>
            public static List<Node> FindPath(Grid grid, Node startNode, Node endNode, Func<Node, Node, bool> tileEvaluationFunction = null, Func<Node, Node, float> heuristicCalculationFunction = null) {

                if (!grid.IsInGrid(startNode) || !grid.IsInGrid(endNode)) {

                    return null;

                }

                Node actualNode, nextNode;
                Node navigationOrderingNode;
                bool stopSearch;

                List<Node> neigbourNodes = new List<Node>();
                List<Node> tilesToCheck = new List<Node>();
                List<Node> tilesChecked = new List<Node>();
                List<Node> path = new List<Node>();

                if (tileEvaluationFunction == null) {

                    tileEvaluationFunction = EvaluationFunctions.FastestPathEvaluationFunction;

                }

                if (heuristicCalculationFunction == null) {

                    heuristicCalculationFunction = HeuristicFunctions.ManhattanHeuristicFunction;

                }

                ClearPathfindingBoard(grid);
                stopSearch = false;
                startNode.Distance = 0;
                tilesToCheck.Add(startNode);

                while (!stopSearch && tilesToCheck.Count > 0) {

                    neigbourNodes.Clear();
                    actualNode = tilesToCheck.First();
                    tilesToCheck.RemoveAt(0);

                    if (actualNode == endNode) { //If the start and end tiles are the same we don't need to search

                        break;

                    }

                    neigbourNodes.AddRange(grid.Neighbours(actualNode));

                    for (int i = 0; i < neigbourNodes.Count; i++) {

                        nextNode = neigbourNodes[i];

                        if (nextNode == endNode) { //If nextNode is the destination we stop the search of the neighbours and we end the search in general

                            nextNode.Previous = actualNode;
                            stopSearch = true;
                            break;

                        }

                        float heuristicDistance = heuristicCalculationFunction(nextNode, endNode);

                        if (!tilesChecked.Contains(nextNode) && tileEvaluationFunction(actualNode, nextNode)) {

                            nextNode.Previous = actualNode;
                            nextNode.Distance = actualNode.Distance + 1; //This is the amount of movement needed to arrive to this tile. G
                            nextNode.Heuristic = heuristicDistance; //This is the heuristic of this tile. H
                            tilesToCheck.Add(nextNode);

                        }

                    }

                    tilesToCheck = tilesToCheck.OrderBy(t => t.Distance + t.Heuristic).ThenBy(t => t.Heuristic).ToList(); //We order the tiles first by the movement to arrive to the end and second by the heuristic
                    tilesChecked.Add(actualNode);

                }


                if (stopSearch) {

                    navigationOrderingNode = endNode;

                    //We create the path going backwards from the endNode
                    while (navigationOrderingNode != null) {

                        path.Insert(0, navigationOrderingNode);
                        navigationOrderingNode = navigationOrderingNode.Previous;

                    }

                    return path;

                } else {

                    return null;

                }

            }


            /// <summary>
            /// Reset the values of Pathfinding in the grid provided
            /// </summary>
            /// <param name="grid"></param>
            private static void ClearPathfindingBoard(Grid board) {

                for (int i = 0; i < board.grid.GetLength(0); i++) {

                    for (int j = 0; j < board.grid.GetLength(1); j++) {

                        board.grid[i, j].ResetPathfindingInThisNode();

                    }

                }


            }

        }

    }

}
