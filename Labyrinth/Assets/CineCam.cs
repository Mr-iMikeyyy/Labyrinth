using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Threading.Tasks;

public class CineCam : MonoBehaviour
{
    GameObject minos;
    CinemachineVirtualCamera  cam;
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(1000);
        minos = GameObject.Find("MinosCinematic(Clone)");
        cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = minos.transform;
        cam.LookAt = minos.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
