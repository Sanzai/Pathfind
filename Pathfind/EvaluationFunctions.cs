namespace FranciscoSarabia {

    namespace Pathfind {

        public class EvaluationFunctions {

            /// <summary>
            /// Evaluates if this path is faster for the node in the pathfinding
            /// </summary>
            /// <param name="actualNode">Node the algorithm is in</param>
            /// <param name="nextNode">Node been evaluated</param>
            /// <returns></returns>
            public static bool FastestPathEvaluationFunction(Node actualNode, Node nextNode) {

                return (nextNode.Distance > actualNode.Distance + 1);

            }

        }

    }

}
