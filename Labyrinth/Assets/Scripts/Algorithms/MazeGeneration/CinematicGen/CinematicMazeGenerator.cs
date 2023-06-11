using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using System.Linq;
using System;
using Random = UnityEngine.Random;

        /**
        --------------------USED ALGORITHM--------------------
        
        Depth-First Search (DFS): This is a recursive algorithm that works by starting at a random cell and randomly choosing
        a neighboring cell to visit. The visited cell is marked and the process is repeated with the newly visited cell until
        all cells have been visited. This algorithm creates mazes with long, winding paths and few branches.
        1.	Initialize a grid of nodes based on a specified Vector size.
        2.  
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

public class CinematicMazeGenerator : MonoBehaviour {
    [SerializeField] MazeNode nodePrefab;
    [SerializeField] GameObject navMesh;
    [SerializeField] GameObject key;

    public GameObject[] objectsToPlace;
    // public GameObject playerCharacter;
    public GameObject enemyCharacter;
    // private Random random = new Random();
    public StringUtils stringUtils = new StringUtils();

    private void Start() {
        SeedFormulas.setSeed("test");
        // Generate a maze with specified size, objects to place, and player character, 
        // and get a list of maze nodes 
        List<MazeNode> completedMazeNodes = GenerateMaze(objectsToPlace, key);
        
        // Bake the generated maze mesh to create a navigation mesh
        BakeMesh();
        
        // Instantiate an enemy character at a specific node in the completed maze nodes list
        int xPosition = MazeParams.getSize().x - 1;
        int yPosition = 0;

        //Saves the RNG so different mazes will be same.
        SeedFormulas.saveState();

        InstantiateMino(completedMazeNodes, xPosition, yPosition);
    }


    // This method bakes the generated maze mesh to create a navigation mesh
    private void BakeMesh() {
        // Get the script that will build the navigation mesh
        MazeNavMeshBuilder navBuilder = navMesh.GetComponent<MazeNavMeshBuilder>();
        
        // Create the navigation mesh using the script
        navBuilder.CreateNavMesh();
    }


    // This method instantiates an enemy character at a specific maze node position
    // The top-left node is 0, 0 and the bottom-right node is (size.x - 1), (size.y - 1)
    private void InstantiateMino(List<MazeNode> completedMazeNodes, int xPosition, int yPosition) {
        // Get the node where the enemy character will be placed
        MazeNode nodeToPlaceMino = GetNodeByName(completedMazeNodes, xPosition, yPosition);
        
        // Get the position of the node and set the y coordinate to 1 to place the enemy character on top of the node
        Vector3 enemyPos = nodeToPlaceMino.transform.position;
        enemyPos.y = 1;
        
        // Instantiate the enemy character at the position of the node
        Instantiate(enemyCharacter, enemyPos, Quaternion.identity);
    }


    /// <summary>
    /// Generates a maze with a specified size, objects to place, and player character, and returns a list of completed maze nodes.
    /// </summary>
    /// <param name="objectsToPlace">An array of GameObjects to be randomly placed in the maze.</param>
    /// <param name="playerCharacter">The GameObject representing the player character.</param>
    /// <returns>A List of MazeNodes representing the completed maze.</returns>
    List<MazeNode> GenerateMaze(GameObject[] objectsToPlace, GameObject key) {
        Vector2Int mazeSize = MazeParams.getSize();

        Stack<MazeNode> currentPath = new Stack<MazeNode>();
        List<MazeNode> completedNodes = new List<MazeNode>();

        List<MazeNode> nodes = CreateMazeGrid(mazeSize);

        PlaceRandom(objectsToPlace, nodes);

        PlaceRooms(mazeSize, nodes, completedNodes, key);

        // Choose starting node
        MazeNode currentNode = GetNodeByName(nodes, 0, 0);

        currentPath.Push(currentNode);
        completedNodes.Add(currentNode);

        while (completedNodes.Count < nodes.Count) {
            List<MazeNode> neighborNodes = GetNeighborNodes(nodes, currentNode);
            Debug.Log($"There are {neighborNodes.Count} neighbor nodes to node: {currentNode.name}");

            // Filter out neighbors that are already in the completedNodes list
            neighborNodes = neighborNodes.Where(node => !completedNodes.Contains(node)).ToList();

            if (neighborNodes.Count > 0) {
                // Choose a random node from the available neighbor nodes
                int randomIndex = Random.Range(0, neighborNodes.Count);
                MazeNode nextNode = neighborNodes[randomIndex];

                // Remove the walls between the currentNode and the nextNode
                RemoveWallsBetween(currentNode, nextNode);

                // Add the selected node to the current path and completed nodes
                currentPath.Push(nextNode);
                completedNodes.Add(nextNode);
                
                // Update the current node
                currentNode = nextNode;
            } else {
                // If there are no uncompleted neighbors, backtrack until we find one
                if (currentPath.Count > 0) {
                    currentNode = currentPath.Pop();
                } else {
                    // If the stack is empty, we have visited all nodes
                    break;
                }
            }
        }

        return completedNodes;
    }

    public void RemoveWallsBetween(MazeNode currentNode, MazeNode nextNode) {
        int currentNodeX = stringUtils.GetNodeX(currentNode.name);
        int currentNodeY = stringUtils.GetNodeY(currentNode.name);
        int nextNodeX = stringUtils.GetNodeX(nextNode.name);
        int nextNodeY = stringUtils.GetNodeY(nextNode.name);

        if (currentNodeX < nextNodeX) {
            currentNode.RemoveWall(0); // Remove right wall of currentNode
            nextNode.RemoveWall(1); // Remove left wall of nextNode
        } else if (currentNodeX > nextNodeX) {
            currentNode.RemoveWall(1); // Remove left wall of currentNode
            nextNode.RemoveWall(0); // Remove right wall of nextNode
        } else if (currentNodeY < nextNodeY) {
            currentNode.RemoveWall(2); // Remove top wall of currentNode
            nextNode.RemoveWall(3); // Remove bottom wall of nextNode
        } else if (currentNodeY > nextNodeY) {
            currentNode.RemoveWall(3); // Remove bottom wall of currentNode
            nextNode.RemoveWall(2); // Remove top wall of nextNode
        }

    }

    // This method should return the list of nodes touching the passed node
    // i.e an outside corner should return 2 nodes
    // an outside edge should return 3 nodes
    // an interior should return 4 nodes
    public List<MazeNode> GetNeighborNodes(List<MazeNode> nodes, MazeNode currentNode) {
        List<MazeNode> neighborNodes = new List<MazeNode>();
        // Create a string with the name of the node to be found
        string name = currentNode.name;
        int currentNodeX = stringUtils.GetNodeX(name);
        int currentNodeY = stringUtils.GetNodeY(name);
        
        // Check the neighbors in each direction: left, right, up, and down
        MazeNode leftNeighbor = GetNodeByName(nodes, currentNodeX - 1, currentNodeY);
        MazeNode rightNeighbor = GetNodeByName(nodes, currentNodeX + 1, currentNodeY);
        MazeNode upNeighbor = GetNodeByName(nodes, currentNodeX, currentNodeY + 1);
        MazeNode downNeighbor = GetNodeByName(nodes, currentNodeX, currentNodeY - 1);

        // Add the neighbors to the list if they are not null
        if (leftNeighbor != null) {
            neighborNodes.Add(leftNeighbor);
        }
        if (rightNeighbor != null) {
            neighborNodes.Add(rightNeighbor);
        }
        if (upNeighbor != null) {
            neighborNodes.Add(upNeighbor);
        }
        if (downNeighbor != null) {
            neighborNodes.Add(downNeighbor);
        }

        return neighborNodes;
    }

    // This method returns a maze node with a specific name from a list of maze nodes
    public MazeNode GetNodeByName(List<MazeNode> nodes, int x, int y) {
        // Create a string with the name of the node to be found
        string nodeName = string.Format("Node_{0}_{1}", x, y);
        
        // Loop through the list of maze nodes to find the node with the specified name
        foreach (MazeNode node in nodes) {
            if (node.name == nodeName) {
                return node;
            }
        }
        
        // Return null if the node with the specified name was not found
        return null;
    }

    // Create the specified grid of nodes
    List<MazeNode> CreateMazeGrid(Vector2Int size) {
        List<MazeNode> nodes = new List<MazeNode>();
        // Create nodes (Initially all nodes will have 4 walls)
        for (int x = 0; x < size.x; x++) {
            for (int y = 0; y < size.y; y++) {
                Vector3 nodePos = new Vector3(x * 4f - (size.x * 2f), 0, y * 4 - (size.y * 2f));
                MazeNode newNode = Instantiate(nodePrefab, nodePos, Quaternion.identity, transform);
                newNode.name = string.Format("Node_{0}_{1}", x, y);
                nodes.Add(newNode);

                newNode.AddPillars(x, y);
                newNode.SetRandomFloorMaterial();
            }
        }
        return nodes;
    }

    
    void PlaceRandom(GameObject[] objectsToPlace, List<MazeNode> nodes){

        GameObject mudPrefab = objectsToPlace[0]; // Mud_A 
        GameObject redMushroomPrefab = objectsToPlace[1]; // mushroom_A
        GameObject brokenRockPrefab = objectsToPlace[2]; // rock_A2
        GameObject rockPrefab = objectsToPlace[3]; // rock_A
        GameObject skullPrefab = objectsToPlace[4]; // skull
        GameObject yellowMushroomPrefab1 = objectsToPlace[5]; // Mushroom1
        GameObject yellowMushroomPrefab2 = objectsToPlace[6]; // Mushroom2
        GameObject redMushroomPrefab1 = objectsToPlace[7]; // Mushroom3
        GameObject redMushroomPrefab2 = objectsToPlace[8]; // Mushroom4

        // Hide yo' random object clutter in this thing
        GameObject placedObjectsParent = new GameObject("PlacedObjects");

        /*
        * =============================================================================================================================
        * The PlaceObjectsRandomly method is being called with the following variables:
        *
        * objectPrefab - the game object prefab to be placed
        * numObjects - the number of objects to place
        * nodes - a list of MazeNode objects that define the maze structure
        * placedObjectsParent - a parent object for the placed objects, used to group them in the Unity Hierarchy
        * add_gravity - a flag indicating whether or not to add a Rigidbody component and enable gravity for the placed objects
        * =============================================================================================================================
        */
        PlaceObjectsRandomly(mudPrefab, 21, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(redMushroomPrefab, 33, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(redMushroomPrefab1, 33, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(redMushroomPrefab2, 33, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(yellowMushroomPrefab1, 33, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(yellowMushroomPrefab2, 33, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(brokenRockPrefab, 250, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(rockPrefab, 250, nodes, placedObjectsParent, false);
        PlaceObjectsRandomly(skullPrefab, 10, nodes, placedObjectsParent, true);
    }

    void PlaceObjectsRandomly(GameObject objectPrefab, int numObjects, List<MazeNode> nodes, GameObject placedObjectsParent, bool add_gravity) {
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

            GameObject newObject = Instantiate(objectPrefab, new Vector3(x, 0, z), Quaternion.Euler(0, Random.Range(0, 360), 0));

            if (add_gravity) {
                // Add Rigidbody component and enable gravity
                Rigidbody rb = newObject.AddComponent<Rigidbody>();
                rb.useGravity = true;
                // Add MeshCollider component
                MeshCollider collider = newObject.AddComponent<MeshCollider>();
                collider.convex = true; // Enable convex mesh collider for more accurate collisions
            }

            // Set the parent of the placed object to the parent GameObject
            newObject.transform.SetParent(placedObjectsParent.transform);
        
            newObject.transform.localScale *= 4f;
            
        }
    }

    void PlaceRooms(Vector2Int size, List<MazeNode> nodes, List<MazeNode> completedNodes, GameObject key){
        /*
        * =============================================================================================================================
        * The CreateRoom method is being called with the following variables:
        *
        *  completedNodes - a list of MazeNode objects that have been completed (i.e., walls have been removed)
        *  nodes - a list of MazeNode objects that define the maze structure
        *  x - the x-coordinate of the top-left node in the room
        *  y - the y-coordinate of the top-left node in the room
        *  is_center_room - a flag indicating whether or not the room is the center room of the maze
        *  starting_room - a flag indicating whether or not the room is the starting room of the maze
        * =============================================================================================================================
        */
        // # topLeft room
        CreateRoom(nodes, completedNodes, 1, size.y - 2, false, 1, key);
        // # topRight room
        CreateRoom(nodes, completedNodes, size.x - 4, size.y - 2, false, 0, key);
        // # Center room
        CreateRoom(nodes, completedNodes, size.x / 2 - 1, size.y / 2 + 1, true, 0, key);
        // # bottomRight room
        CreateRoom(nodes, completedNodes, size.x - 4, 3, false, 2, key);
        // # bottomLeft room
        CreateRoom(nodes, completedNodes, 1, 3, false, 0, key);
    }

    /*
    * =============================================================================================================================
    * The CreateRoom method is being called with the following variables:
    *
    **  nodes - a list of MazeNode objects that define the maze structure
    **  completedNodes - a list of MazeNode objects that have been completed (i.e., walls have been removed)
    **  x - the x-coordinate of the top-left node in the room
    **  y - the y-coordinate of the top-left node in the room
    **  is_center_room - a flag indicating whether or not the room is the center room of the maze
    **  starting_room - a flag indicating whether or not the room is the starting room of the maze
    *
    * The method creates a room by removing walls from the MazeNode objects corresponding to the top-left, top-center, top-right,
    * center-left, center, center-right, bottom-left, bottom-center, bottom-right, bottom-left-door, and top-right-door nodes
    * in the room. The method also adds a chest to the top-center node, sets the center node as the completion node if the room
    * is the center room, adds a table to the center node if the room is not the center room, and places the player character at the
    * center-left node if the room is the starting room. The method also adds doors to the bottom-left-door and top-right-door
    * nodes if the room is not the center room.
    *   CreateRoom:
    *   This method takes in a list of nodes, a list of completed nodes, a x and y position of the top left node of a room.
    *   It creates a room by identifying the 9 nodes that make up the room and removes the walls between them, based on their location
    *   relative to each other. If an outside door is required, it removes the top wall of the bottom left node or the bottom wall of
    *   the top right node.
    * =============================================================================================================================
    */
    void CreateRoom(List<MazeNode> nodes, List<MazeNode> completedNodes, int x, int y, bool is_center_room, int room, GameObject key) {
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

        // Top left
        if (topLeft != null) {
            completedNodes.Add(topLeft);
            topLeft.RemoveWall(0); // RIGHT
            topLeft.RemoveWall(3); // BOTTOM
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
        // Top right
        if (topRight != null) {
            completedNodes.Add(topRight);
            topRight.RemoveWall(1); // LEFT
            topRight.RemoveWall(3); // BOTTOM
            topRight.RemoveWall(2); // TOP
        }


        // Center left
        if (centerLeft != null) {
            completedNodes.Add(centerLeft);
            centerLeft.RemoveWall(0); // RIGHT
            centerLeft.RemoveWall(2); // TOP
            centerLeft.RemoveWall(3); // BOTTOM
            centerLeft.RemovePillar(0);
            // if (room == 1) {
            //     playerCharacter.transform.position = centerLeft.transform.position;
            // }
        }

        // Center
        if (center != null) {
            completedNodes.Add(center);
            center.RemoveWall(0); // RIGHT
            center.RemoveWall(1); // LEFT
            center.RemoveWall(2); // TOP
            center.RemoveWall(3); // BOTTOM
            center.RemovePillar(0);
            if (is_center_room)  {
                // center.addLadder();
                center.SetAsCompletionNode();
            } else {
                center.AddTable();
                if (room == 2) {
                    // Get the center position of the node's floor
                    Vector3 floorCenter = center.GetFloor().bounds.center;
                    floorCenter = new Vector3(floorCenter.x, floorCenter.y + 4, floorCenter.z);

                    // Instantiate the key prefab at the center position
                    GameObject keyObject = Instantiate(key, floorCenter, Quaternion.identity, transform);
                    keyObject.name = "Key";
                }
            }
        }

        // Center right
        if (centerRight != null) {
            completedNodes.Add(centerRight);
            centerRight.RemoveWall(1); // LEFT
            centerRight.RemoveWall(2); // TOP
            centerRight.RemoveWall(3); // BOTTOM
        }

        // Bottom left
        if (bottomLeft != null) {
            completedNodes.Add(bottomLeft);
            bottomLeft.RemoveWall(0); // RIGHT
            bottomLeft.RemoveWall(2); // TOP
            bottomLeft.RemoveWall(3); // BOTTOM
            bottomLeft.RemovePillar(0);
        }

        // Bottom center
        if (bottomCenter != null) {
            completedNodes.Add(bottomCenter);
            bottomCenter.RemoveWall(1); // LEFT
            bottomCenter.RemoveWall(0); // RIGHT
            bottomCenter.RemoveWall(2); // TOP
            bottomCenter.RemovePillar(0);
        }

        // Bottom right
        if (bottomRight != null) {
            completedNodes.Add(bottomRight);
            bottomRight.RemoveWall(1); // LEFT
            bottomRight.RemoveWall(2); // TOP
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

}