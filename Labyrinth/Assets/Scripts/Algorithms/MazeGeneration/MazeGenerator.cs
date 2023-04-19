using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    // [SerializeField] MazeNode blankNodePrefab;
    [SerializeField] Vector2Int mazeSize;
    // [SerializeField] float nodeSize;
    public GameObject[] objectsToPlace;
    public GameObject playerCharacter;
    public GameObject enemyCharacter;
    private MazeNode[] completedMazeNodes;

    private NavMeshSurface[] navMeshSurfaces;

    private void Start() {
        GenerateMazeInstant(MazeParams.getSize(), objectsToPlace, playerCharacter);
        BakeMesh()
        InstantiateMino()
        //StartCoroutine(GenerateMaze(mazeSize));
    }

    private void BakeMesh() {
        // Add each MazeNode mesh surface to local array or surfaces
        foreach (MazeNode node in completedMazeNodes) {
            NavMeshSurface surface = node.GetNavMeshSurface;
            navMeshSurfaces.add(surface);
        }

        // Bake the Mesh
        for (int i = 0; i < navMeshSurfaces.Length; i++) {
            navMeshSurfaces[i].BuildNavMesh();
        }

    }

    private void InstantiateMino() {
        

    }

    public MazeNode GetNodeByName(List<MazeNode> nodes, int x, int y) {
        string nodeName = string.Format("Node_{0}_{1}", x, y);
        foreach (MazeNode node in nodes) {
            if (node.name == nodeName) {
                return node;
            }
        }
        return null;
    }


    /**
        CreateRoom:
        This method takes in a list of nodes, a list of completed nodes, a x and y position of the top left node of a room.
        It creates a room by identifying the 9 nodes that make up the room and removes the walls between them, based on their location
        relative to each other. If an outside door is required, it removes the top wall of the bottom left node or the bottom wall of
        the top right node.
    **/
    void CreateRoom(List<MazeNode> nodes, List<MazeNode> completedNodes, int x, int y, bool is_center_room, int starting_room) {
        // MazeNode centerCenter = GetNodeByName(nodes, )
        MazeNode topLeft = GetNodeByName(nodes, x, y);
        MazeNode topCenter = GetNodeByName(nodes, x + 1, y);
        MazeNode topRight = GetNodeByName(nodes, x + 2, y);
        MazeNode centerLeft = GetNodeByName(nodes, x, y - 1);
        MazeNode center = GetNodeByName(nodes, x + 1, y - 1);
        MazeNode centerRight = GetNodeByName(nodes, x + 2, y - 1);
        MazeNode bottomLeft = GetNodeByName(nodes, x, y - 2);
        MazeNode bottomCenter = GetNodeByName(nodes, x + 1, y - 2);
        MazeNode bottomRight = GetNodeByName(nodes, x + 2, y - 2);
        MazeNode bottomLeftDoor = GetNodeByName(nodes, x, y - 3);
        MazeNode topRightDoor = GetNodeByName(nodes, x + 2, y + 1);

        if (topLeft != null) {
            completedNodes.Add(topLeft);
            topLeft.RemoveWall(0); // RIGHT
            topLeft.RemoveWall(3); // BOTTOM
        }

        // Top right
        if (topRight != null) {
            completedNodes.Add(topRight);
            topRight.RemoveWall(1); // LEFT
            topRight.RemoveWall(3); // BOTTOM
            topRight.RemoveWall(2); // TOP
        }

        // Bottom right
        if (bottomRight != null) {
            completedNodes.Add(bottomRight);
            bottomRight.RemoveWall(1); // LEFT
            bottomRight.RemoveWall(2); // TOP
        }

        // Top center
        if (topCenter != null) {
            completedNodes.Add(topCenter);
            topCenter.RemoveWall(0); // RIGHT
            topCenter.RemoveWall(1); // LEFT
            topCenter.RemoveWall(3); // BOTTOM
            topCenter.AddChest();
            if (is_center_room)  {

            } else {

            }
        }

        // Center left
        if (centerLeft != null) {
            completedNodes.Add(centerLeft);
            centerLeft.RemoveWall(0); // RIGHT
            centerLeft.RemoveWall(2); // TOP
            centerLeft.RemoveWall(3); // BOTTOM
            if (starting_room == 1) {
                playerCharacter.transform.position = centerLeft.transform.position;
            }
        }

        // Center
        if (center != null) {
            completedNodes.Add(center);
            center.RemoveWall(0); // RIGHT
            center.RemoveWall(1); // LEFT
            center.RemoveWall(2); // TOP
            center.RemoveWall(3); // BOTTOM
            if (is_center_room)  {
                // center.addLadder();
                center.SetAsCompletionNode();
            } else {
                center.AddTable();
            }
            
        }

        // Center right
        if (centerRight != null) {
            completedNodes.Add(centerRight);
            centerRight.RemoveWall(1); // LEFT
            centerRight.RemoveWall(2); // TOP
            centerRight.RemoveWall(3); // BOTTOM
        }

        // Bottom center
        if (bottomCenter != null) {
            completedNodes.Add(bottomCenter);
            bottomCenter.RemoveWall(1); // LEFT
            bottomCenter.RemoveWall(0); // RIGHT
            bottomCenter.RemoveWall(2); // TOP
            // centerRight.RemoveWall(3); // BOTTOM
        }

        // Bottom left
        if (bottomLeft != null) {
            completedNodes.Add(bottomLeft);
            bottomLeft.RemoveWall(0); // RIGHT
            bottomLeft.RemoveWall(2); // TOP
            bottomLeft.RemoveWall(3); // BOTTOM
        }

        // Outside Door
        if (bottomLeftDoor != null) {
                bottomLeftDoor.AddDoor(2, is_center_room); // TOP
        }
        // Outside Door
        if (topRightDoor != null) {
                topRightDoor.AddDoor(3, is_center_room); // BOTTOM

        }

    }

    void PlaceObjectsRandomly(GameObject objectPrefab, int numObjects, List<MazeNode> nodes, bool add_gravity) {
        for (int i = 0; i < numObjects; i++) {
            // Place object at random position in the maze
            float minX = float.MaxValue;
            float minZ = float.MaxValue;
            float maxX = float.MinValue;
            float maxZ = float.MinValue;
            foreach (MazeNode node in nodes) {
                minX = Mathf.Min(minX, node.transform.position.x);
                minZ = Mathf.Min(minZ, node.transform.position.z);
                maxX = Mathf.Max(maxX, node.transform.position.x);
                maxZ = Mathf.Max(maxZ, node.transform.position.z);
            }
            float x = UnityEngine.Random.Range(minX, maxX);
            float z = UnityEngine.Random.Range(minZ, maxZ);
            GameObject newObject = Instantiate(objectPrefab, new Vector3(x, 0, z), Quaternion.identity);

            if (add_gravity) {
                // Add Rigidbody component and enable gravity
                Rigidbody rb = newObject.AddComponent<Rigidbody>();
                rb.useGravity = true;

                // Add MeshCollider component
                MeshCollider collider = newObject.AddComponent<MeshCollider>();
                collider.convex = true; // Enable convex mesh collider for more accurate collisions
            }


        }
    }

    void GenerateMazeInstant(Vector2Int size, GameObject[] objectsToPlace, GameObject playerCharacter) {
        List<MazeNode> nodes = new List<MazeNode>();
        List<MazeNode> currentPath = new List<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        GameObject objectPrefab = objectsToPlace[0]; // Mud_A 
        GameObject objectPrefab1 = objectsToPlace[1]; // mushroom_A
        GameObject objectPrefab2 = objectsToPlace[2]; // rock_A2
        GameObject objectPrefab3 = objectsToPlace[3]; // rock_A
        GameObject objectPrefab4 = objectsToPlace[4]; // skull
        GameObject objectPrefab5 = objectsToPlace[5]; // PowerUp

        // Create nodes (Initially all nodes will have 4 walls)
        for (int w = 0; w < size.x; w++) {
            for (int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(w - (size.x / 2f), 0, y - (size.y / 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                newNode.name = string.Format("Node_{0}_{1}", w, y);
                nodes.Add(newNode);
            }
        }

        PlaceObjectsRandomly(objectPrefab, 21, nodes, false);
        PlaceObjectsRandomly(objectPrefab1, 33, nodes, false);
        PlaceObjectsRandomly(objectPrefab2, 150, nodes, false);
        PlaceObjectsRandomly(objectPrefab3, 150, nodes, false);
        PlaceObjectsRandomly(objectPrefab4, 10, nodes, true);
        // PlaceObjectsRandomly(objectPrefab5, 30, nodes, false);
        
        
        // # topLeft room
        CreateRoom(nodes, completedNodes, 1, size.y - 2, false, 1);
        // # topRight room
        CreateRoom(nodes, completedNodes, size.x - 4, size.y - 2, false, 0);
        // # Center room
        CreateRoom(nodes, completedNodes, size.x / 2 - 1, size.y / 2 + 1, true, 0);
        // # bottomRight room
        CreateRoom(nodes, completedNodes, size.x - 4, 3, false, 0);
        // # bottomLeft room
        CreateRoom(nodes, completedNodes, 1, 3, false, 0);



        // Choose starting node
        currentPath.Add(nodes[nodes.Count / 2 - size.x + 2]);
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
                // Local array for NavMesh baking
                completedMazeNodes.Add(urrentPath[currentPath.Count - 1]);
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