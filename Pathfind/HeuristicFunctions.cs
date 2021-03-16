using UnityEngine;

namespace FranciscoSarabia {

    namespace Pathfind {

        public class HeuristicFunctions {

            /// <summary>
            /// Manhattan distance calculation function for the heuristic value of a node 
            /// </summary>
            /// <param name="actualNode">Node that we calculate the heuristic from</param>
            /// <param name="destinationNode">Node that we calculate the heuristic to</param>
            /// <returns></returns>
            public static float ManhattanHeuristicFunction(Node actualNode, Node destinationNode) {

                return Mathf.Abs(destinationNode.X - actualNode.X) + Mathf.Abs(destinationNode.Y - actualNode.Y);

            }

            /// <summary>
            /// Diagonal distance calculation function for the heuristic value of a node
            /// </summary>
            /// <param name="actualNode">Node that we calculate the heuristic from</param>
            /// <param name="destinationNode">Node that we calculate the heuristic to</param>
            /// <returns></returns>
            public static float DiagonalDistanceHeuristicFunction(Node actualNode, Node destinationNode) {

                int distanceX = Mathf.Abs(destinationNode.X - actualNode.X);
                int distanceY = Mathf.Abs(destinationNode.Y - actualNode.Y);

                return (distanceX + distanceY) - 1 * Mathf.Min(distanceX, distanceY); //Chebyshev distance because all movements cost 1

            }

        }

    }

}