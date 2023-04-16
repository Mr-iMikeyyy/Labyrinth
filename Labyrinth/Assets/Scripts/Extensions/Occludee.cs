using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Occludee : MonoBehaviour
{
    public bool specialCondition { get; set; }

    // Upon creation, add to ocludee list
    private void Awake()
    {
        MazeGenerator.Instance.Occludees.Add(new KeyValuePair<int, Occludee>(this.gameObject.GetInstanceID(), this));
    }

    // Upon destory, remove from ocludee list
    private void OnDestroy()
    {
        MazeGenerator.Instance.Occludees.Remove(new KeyValuePair<int, Occludee>(this.gameObject.GetInstanceID(), this));
    }
}
