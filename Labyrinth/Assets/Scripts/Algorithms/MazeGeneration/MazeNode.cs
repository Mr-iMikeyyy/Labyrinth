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
    [SerializeField] MeshRenderer floor;

    public void RemoveWall(int wallToRemove) {
        walls[wallToRemove].gameObject.SetActive(false);
    }
    public void AddDoor(int wallToRemove, GameObject doorPrefab) {
        Vector3 wallPosition = walls[wallToRemove].transform.position;
        Quaternion wallRotation = walls[wallToRemove].transform.rotation;
        Destroy(walls[wallToRemove].gameObject);
        GameObject doorObject = Instantiate(doorPrefab, wallPosition, wallRotation, transform);
        doorObject.name = "Door";
    }
    public void AddWall(int wallToAdd) {
        walls[wallToAdd].gameObject.SetActive(true);
    }

    public void SetState(NodeState state) {
        switch (state) {
            case NodeState.Available:
                floor.material.color = Color.white;
                break;
            case NodeState.Current:
                floor.material.color = Color.yellow;
                break;
            case NodeState.Completed:
                floor.material.color = Color.blue;
                break;
        }
    }
}