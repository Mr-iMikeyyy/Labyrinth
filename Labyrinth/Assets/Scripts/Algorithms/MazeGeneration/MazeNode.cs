using UnityEngine;
using Unity.AI.Navigation;
using System;


public enum NodeState {
    Available,
    Current,
    Completed
}

public class MazeNode : MonoBehaviour {
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject[] pillars;
    [SerializeField] GameObject[] stoneMaterials;
    [SerializeField] GameObject LockedDoor;
    [SerializeField] GameObject UnlockedDoor;
    private GameObject doorObject;
    [SerializeField] GameObject Ceiling;
    [SerializeField] GameObject Light;
    [SerializeField] GameObject CenterCollider;
    [SerializeField] GameObject Table;
    [SerializeField] GameObject Stool;
    [SerializeField] GameObject Torch;
    [SerializeField] GameObject Chest;
    [SerializeField] GameObject Latern;
    [SerializeField] GameObject Ladder;
    [SerializeField] MeshRenderer floor;
    [SerializeField] Material floorMaterial;
    [SerializeField] GameObject floorObject;
    [SerializeField] NavMeshSurface surface;

    private void Awake() {
        floor.gameObject.SetActive(true);
        Ladder.gameObject.SetActive(false);
        Array.ForEach(pillars, pillar => RandomizePillar(pillar));
    }

    public void RemoveWall(int wallToRemove) {
        walls[wallToRemove].gameObject.SetActive(false);
    }

    public void RemovePillar(int pillarToRemove) {
        pillars[pillarToRemove].gameObject.SetActive(false);
    }
    public void AddPillars(int x, int y) {
        Vector2Int mazeSize = MazeParams.getSize();

        if (x == 0 && y == 0) {
            // Top-left node: add pillars 1 and 2
            pillars[0].gameObject.SetActive(true);
            pillars[1].gameObject.SetActive(true);
            pillars[2].gameObject.SetActive(true);
            pillars[3].gameObject.SetActive(true);
        } else if (x == 0) {
            // Left side, excluding bottom-left node: add pillars 1 and 2
            pillars[0].gameObject.SetActive(true);
            pillars[3].gameObject.SetActive(true);
        } else if (y == 0) {
            // Bottom row, excluding bottom-left node: add pillars 2 and 4
            pillars[0].gameObject.SetActive(true);
            pillars[1].gameObject.SetActive(true);
        } else {
            // Bottom-right node: add all 4 pillars
            pillars[0].gameObject.SetActive(true);
        }
    }

    public void RandomizePillar(GameObject pillar){
        int randomRotation = UnityEngine.Random.Range(0, 4) * 90;
        pillar.transform.rotation = Quaternion.Euler(0, randomRotation, 0);
        pillar.gameObject.SetActive(false);
    }
    public MeshRenderer GetFloor() {
        return floor;
    }
    public void SetRandomFloorMaterial() {
        int randomRotation = UnityEngine.Random.Range(0, 4) * 180;
        floor.transform.rotation = Quaternion.Euler(0, randomRotation, 0);
    }

    
    public void AddDoor(int wallToRemove, bool is_center_room) {
        Vector3 wallPosition = walls[wallToRemove].transform.position;
        Quaternion wallRotation = walls[wallToRemove].transform.rotation;
        Destroy(walls[wallToRemove].gameObject);
        if (is_center_room)
        {
            doorObject = Instantiate(LockedDoor, wallPosition, wallRotation, transform);
        }
        else
        {
            doorObject = Instantiate(UnlockedDoor, wallPosition, wallRotation, transform);
        }
        doorObject.name = "Door";
        if (is_center_room) {

        }
    }
    public void AddWall(int wallToAdd) {
        walls[wallToAdd].gameObject.SetActive(true);
    }
public void AddTable() {
    // Get the center position of the node's floor
    Vector3 floorCenter = floor.bounds.center;

    // Instantiate the table prefab at the center position
    GameObject tableObject = Instantiate(Table, floorCenter, Quaternion.identity, transform);
    tableObject.name = "Table";

    // Add a collider component to the table object
    BoxCollider collider = tableObject.AddComponent<BoxCollider>();

}
    
public void AddChest() {
    Vector3 centerPos = transform.position;

    Vector3 chestPos = new Vector3(centerPos.x, centerPos.y, centerPos.z);

    // Instantiate a new chest object at the calculated position
    GameObject chestObject = Instantiate(Chest, chestPos, Quaternion.identity);

    // Parent the chest object to the current node
    chestObject.transform.parent = transform;

    // Rotate the chestObject on the Y axis by 0 degrees (or any other value you want)
    Vector3 chestRotation = chestObject.transform.rotation.eulerAngles;
    chestRotation.y += 180;
    chestObject.transform.rotation = Quaternion.Euler(chestRotation);

}


    public void SetAsCompletionNode() {
        Ceiling.gameObject.SetActive(false);
        // Light.gameObject.SetActive(true);
        // floor.material = floorMaterial;
        // Get the center position of the node's floor
        Vector3 floorCenter = floor.bounds.center;

        // Instantiate the table prefab at the center position
        GameObject lightObject = Instantiate(Light, floorCenter, Quaternion.identity, transform);
        lightObject.name = "Light";

        
        // GameObject ladderObject = Instantiate(Ladder, floorCenter, Quaternion.identity, transform);
        // ladderObject.name = "Ladder";

        GameObject collider = Instantiate(CenterCollider, floorCenter, Quaternion.identity, transform);
        Vector3 newPos = collider.transform.position;
        newPos.y += 0.5f;
        collider.transform.position = newPos;
        collider.name = "Continue";
        
    }

    public void SetState(NodeState state) {
        switch (state) {
            case NodeState.Available:
                // floor.material.color = Color.white;
                break;
            case NodeState.Current:
                // floor.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                // floor.material.color = Color.blue;
                break;
        }
    }
}