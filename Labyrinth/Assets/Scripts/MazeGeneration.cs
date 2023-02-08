using UnityEngine;

public class MazeGeneration : MonoBehaviour { 

    // TODO: Need Walls, Floor, 3 starting rooms, 1 finish room, minotaur and Player and the methods, variable, and classes associated with them

    /**
        ----EXAMPLES OF COMMONLY USED ALGORITHIMS----

        Randomized Prim's Algorithm: This is a randomized version of Prim's algorithm for generating minimum spanning trees.
        It works by starting with a grid of walls and randomly selecting a wall to remove. If the wall separates two unconnected 
        areas, a room is created and the process is repeated with the newly created room until all rooms are connected. This 
        algorithm creates mazes with a dense cluster of walls in the center and fewer walls towards the outer regions.

        Depth-First Search (DFS): This is a recursive algorithm that works by starting at a random cell and randomly choosing
        a neighboring cell to visit. The visited cell is marked and the process is repeated with the newly visited cell until
        all cells have been visited. This algorithm creates mazes with long, winding paths and few branches.

        Breadth-First Search (BFS): This is an iterative algorithm that works by starting at a random cell and visiting all of
        its neighbors before moving on to the next set of neighbors. The visited cells are marked and the process is repeated until
        all cells have been visited. This algorithm creates mazes with short, straight paths and many branches.

        Kruskal's Algorithm: This is an algorithm for generating minimum spanning trees, similar to Prim's algorithm. It works by 
        sorting the edges of the grid in order of length and adding each edge to the maze as long as it does not create a cycle. 
        This algorithm creates mazes with a sparse cluster of walls and many longer paths connecting the rooms.

        Recursive Division: This is a recursive algorithm that works by dividing the grid into smaller rectangles and creating walls
        to separate them. The process is repeated with each newly created rectangle until the rectangles are small enough to be
        considered rooms. This algorithm creates mazes with straight walls and few branches.
    **/

    // 2D array to store the grid that represents the maze is a common approach
    private Transform[,] grid;
    private List<Vector3> startingRooms = new List<Vector3>();

    private void GenerateMaze() {

    }

    //---- Some random methods to generate
    //TODO: Research methods to use and algorithims to use to generate maze 
    private void PlaceCenterRoom() {

    }

    private void PlaceStartingRooms() {

    }

    private void GenerateWallsAndFloor() {

    }
}