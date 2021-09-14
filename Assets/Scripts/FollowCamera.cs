using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0.0f, 3.0f, -3.5f);
        transform.position = player.transform.position +offset;
        startRotation = transform.rotation;
        
    }

    private static Quaternion CameraRotation(float x, float y, float z)
    {
        return new Quaternion(x, y, z, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        if(Input.GetMouseButtonDown(1))
        {
            if (transform.rotation == startRotation)
            {
                transform.rotation = CameraRotation(0, 0, 0);
            }
            if(transform.rotation != startRotation)
            {
                transform.RotateAround(player.transform.position, new Vector3(0, 25, 0), 25);
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = startRotation;
        }
    }
}
