using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAnimator : MonoBehaviour
{
    public Helicopter helicopter;
    public float RotSpeed = 1000f;
    public Transform _Roter1;
    public Transform _Roter2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Roter1.Rotate(0, 0, helicopter.Throttel * RotSpeed);
        _Roter2.Rotate(0, 0, helicopter.Throttel * -RotSpeed);
    }
}
