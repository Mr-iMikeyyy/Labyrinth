using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour {
        /**
            --------------------USED ALGORITHM--------------------
            
            Depth-First Search (DFS): This is a recursive algorithm that works by starting at a random cell and randomly choosing
            a neighboring cell to visit. The visited cell is marked and the process is repeated with the newly visited cell until
            all cells have been visited. This algorithm creates mazes with long, winding paths and few branches.

            1.	Initialize a list of nodes to include in the maze, where each node represents a square in the maze.
            2.	Choose a starting node from the list of nodes.
            3.	Mark the starting node as visited and add it to the list of completed nodes.
            4.	Initialize a current path with the starting node in it.
            5.	While the list of completed nodes is not equal to the list of all nodes:
                a.	Check the nodes next to the current node in the current path.
                b.	If there is an unvisited neighboring node, choose one at random and move to it.
                c.	Delete both walls between the current node and the chosen node.
                d.	Mark the chosen node as visited and add it to the list of completed nodes.
                e.	Add the chosen node to the current path.
                6.	When all nodes have been visited, the maze is complete.
            DFS works by exploring the maze by moving to neighboring nodes and deleting walls between them, which creates a path through the maze. 
            It continues until all nodes have been visited, ensuring that there is a path between any two nodes in the maze. The algorithm maintains 
            a list of completed nodes, a current path, and a list of unvisited nodes, and randomly chooses the next node to visit. By using a random 
            selection, the algorithm generates unique mazes every time it is run.


        **/
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] MazeNode blankNodePrefab;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] float nodeSize;

    private void Start() {
        GenerateMazeInstant(mazeSize);
        //StartCoroutine(GenerateMaze(mazeSize));
    }

    void GenerateMazeInstant(Vector2Int size) {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create nodes (Initially all nodes will have 4 walls)
        for (int x = 0; x < size.x; x++) {
            for (int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                newNode.name = string.Format("Node_{0}_{1}", x, y);

                //
                // TODO: FINISH ADDING LOGIC TO CREATE ROOMS
                //


                // if (x >= size.x / 2 - 1 && x <= size.x / 2 + 1 && y >= size.y / 2 - 1 && y <= size.y / 2 + 1) 
                //     if (x == size.x / 2 - 1) {
                //         newNode.RemoveWall(3); // Remove west wall
                //     }
                //     else if (x == size.x / 2 + 1) {
                //         newNode.RemoveWall(2); // Remove east wall
                //     }

                //     if (y == size.y / 2 - 1) {
                //         newNode.RemoveWall(1); // Remove north wall
                //     }
                //     else if (y == size.y / 2 + 1) {
                //         newNode.RemoveWall(0); // Remove south wall
                //     }
                // }
                nodes.Add(newNode);
            }
        }
                        // // Remove top wall of the chosen node, and bottom wall of the current node
                        // chosenNode.RemoveWall(1);
                        // // Remove bottom wall of the chosen node, and top wall of the current node
                        // chosenNode.RemoveWall(0);
                        // // Remove left wall of the chosen node, and right wall of the current node
                        // chosenNode.RemoveWall(3);
                        // // Remove right wall of the chosen node, and left wall of the current node
                        // chosenNode.RemoveWall(2);

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[nodes.Count / 2]);
        currentPath[0].SetState(NodeState.Current);



        while (completedNodes.Count < nodes.Count) {

            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();


            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

        
            if (currentNodeX < size.x - 1) {
                // Check node to the right of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + size.y])) {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0) {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y])) {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1) {
                // Check node above the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1])) {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0) {
                // Check node below the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1])) {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0) {
                // Choose a random direction from the possibleDirections list
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                // Get the node corresponding to the chosen direction
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                // Depending on the chosen direction, remove the wall between the current node and the chosen node
                switch (possibleDirections[chosenDirection]) {
                    case 1:
                        // Remove top wall of the chosen node, and bottom wall of the current node
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        // Remove bottom wall of the chosen node, and top wall of the current node
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        // Remove left wall of the chosen node, and right wall of the current node
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        // Remove right wall of the chosen node, and left wall of the current node
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                // Add the chosen node to the current path
                currentPath.Add(chosenNode);
                // Set the state of the chosen node to "Current"
                chosenNode.SetState(NodeState.Current);
            }
            else {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

    IEnumerator GenerateMaze(Vector2Int size)
    {
        List<MazeNode> nodes = new List<MazeNode>();

        // Create nodes
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector3 nodePos = new Vector3(x - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                nodes.Add(newNode);

                yield return null;
            }
        }

        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        // Choose starting node
        currentPath.Add(nodes[Random.Range(0, nodes.Count)]);
        currentPath[0].SetState(NodeState.Current);

        while (completedNodes.Count < nodes.Count)
        {
            // Check nodes next to the current node
            List<int> possibleNextNodes = new List<int>();
            List<int> possibleDirections = new List<int>();

            int currentNodeIndex = nodes.IndexOf(currentPath[currentPath.Count - 1]);
            int currentNodeX = currentNodeIndex / size.y;
            int currentNodeY = currentNodeIndex % size.y;

            if (currentNodeX < size.x - 1)
            {
                // Check node to the right of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + size.y]) && 
                    !currentPath.Contains(nodes[currentNodeIndex + size.y]))
                {
                    possibleDirections.Add(1);
                    possibleNextNodes.Add(currentNodeIndex + size.y);
                }
            }
            if (currentNodeX > 0)
            {
                // Check node to the left of the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - size.y]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - size.y]))
                {
                    possibleDirections.Add(2);
                    possibleNextNodes.Add(currentNodeIndex - size.y);
                }
            }
            if (currentNodeY < size.y - 1)
            {
                // Check node above the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex + 1]))
                {
                    possibleDirections.Add(3);
                    possibleNextNodes.Add(currentNodeIndex + 1);
                }
            }
            if (currentNodeY > 0)
            {
                // Check node below the current node
                if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                    !currentPath.Contains(nodes[currentNodeIndex - 1]))
                {
                    possibleDirections.Add(4);
                    possibleNextNodes.Add(currentNodeIndex - 1);
                }
            }

            // Choose next node
            if (possibleDirections.Count > 0)
            {
                int chosenDirection = Random.Range(0, possibleDirections.Count);
                MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                switch (possibleDirections[chosenDirection])
                {
                    case 1:
                        chosenNode.RemoveWall(1);
                        currentPath[currentPath.Count - 1].RemoveWall(0);
                        break;
                    case 2:
                        chosenNode.RemoveWall(0);
                        currentPath[currentPath.Count - 1].RemoveWall(1);
                        break;
                    case 3:
                        chosenNode.RemoveWall(3);
                        currentPath[currentPath.Count - 1].RemoveWall(2);
                        break;
                    case 4:
                        chosenNode.RemoveWall(2);
                        currentPath[currentPath.Count - 1].RemoveWall(3);
                        break;
                }

                currentPath.Add(chosenNode);
                chosenNode.SetState(NodeState.Current);
            }
            else
            {
                completedNodes.Add(currentPath[currentPath.Count - 1]);

                currentPath[currentPath.Count - 1].SetState(NodeState.Completed);
                currentPath.RemoveAt(currentPath.Count - 1);
            }

            yield return new WaitForSeconds(0.05f);
        }
    }
}