using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {
    private Vector3 cameraOffset;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //#1 - Camera follows player
        //cameraOffset = transform.position - player.transform.position;
        
        //#2 - Camera behind player (rotates)
        cameraOffset = new Vector3(0.0f, 15f, -18.0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //#1 - Camera follows player
        //transform.position = player.transform.position + cameraOffset;
        
        //#2 - Camera behind player
        transform.position = player.transform.TransformPoint(cameraOffset);
        transform.LookAt(player.transform);
    }
}
