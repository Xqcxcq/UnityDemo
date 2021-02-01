using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Win : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainCamera;
    GameObject camera1;
    GameObject camera2;
    void Start()
    {
        mainCamera = GameObject.Find("Camera");
        camera1 = GameObject.Find("Camera1");
        camera2 = GameObject.Find("Camera2");
        mainCamera.SetActive(false);
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
