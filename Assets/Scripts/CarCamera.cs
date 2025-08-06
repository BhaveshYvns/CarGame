using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CarTransform;
    public Transform CameraPoint;

    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(CarTransform);
        transform.position = Vector3.SmoothDamp(transform.position, CameraPoint.position, ref velocity, 5f * Time.deltaTime);
    }
}
