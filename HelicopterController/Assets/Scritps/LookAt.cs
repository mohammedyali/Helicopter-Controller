using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform Target;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Target);
        if (Input.GetKey(KeyCode.F) && Vector3.Distance(Target.position, transform.position) < 1000)
        {
            camera.fieldOfView = 30 * ((1000 - Vector3.Distance(Target.position, transform.position)) / 1000);
        }
        else
        {
            camera.fieldOfView = 60;
        }
    }
}
