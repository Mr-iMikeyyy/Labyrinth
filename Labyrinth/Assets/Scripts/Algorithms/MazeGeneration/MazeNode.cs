using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState {
    Available,
    Current,
    Completed
}

public class MazeNode : MonoBehaviour {
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject Door;
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

    private void Awake() {
        floor.gameObject.SetActive(true);
        Ladder.gameObject.SetActive(false);
        
        // Light.gameObject.SetActive(false);
        // floor.material = floorMaterial; // set the floor material
    }

    public void RemoveWall(int wallToRemove) {
        walls[wallToRemove].gameObject.SetActive(false);
        // floor.gameObject.SetActive(true);
    }
    public void AddDoor(int wallToRemove, bool is_center_room) {
        Vector3 wallPosition = walls[wallToRemove].transform.position;
        Quaternion wallRotation = walls[wallToRemove].transform.rotation;
        Destroy(walls[wallToRemove].gameObject);
        GameObject doorObject = Instantiate(Door, wallPosition, wallRotation, transform);
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
    }
    public void AddChest() {
        Vector3 centerPos = transform.position;
        float distanceZ = transform.localScale.z / 2f;
        float offsetZ = distanceZ * 0.25f;
        Vector3 chestPos = new Vector3(centerPos.x, centerPos.y, centerPos.z + offsetZ);
        // Rotate the chest GameObject on the Y axis by 0 degrees

        Vector3 chestRotation = Chest.transform.rotation.eulerAngles;
        chestRotation.y += 0;
        Chest.transform.rotation = Quaternion.Euler(chestRotation);

        // Scale the chest GameObject by 50% in all directions
        // Vector3 chestScale = Chest.transform.localScale * 0.5f;
        // Chest.transform.localScale = chestScale;
        // Instantiate a new chest object at the calculated position
        GameObject chestObject = Instantiate(Chest, chestPos, Quaternion.identity);

        // Parent the chest object to the current node
        chestObject.transform.parent = transform;
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