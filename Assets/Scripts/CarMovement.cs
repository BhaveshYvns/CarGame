using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] public WheelCollider FrontRightWheelCollider;
    [SerializeField] public WheelCollider FrontLeftWheelCollider;
    [SerializeField] public WheelCollider BackRightWheelCollider;
    [SerializeField] public WheelCollider BackLeftWheelCollider;

    [SerializeField] public Transform frontRightWheelTransform;
    [SerializeField] public Transform frontLeftWheelTransform;
    [SerializeField] public Transform backRightWheelTransform;
    [SerializeField] public Transform backLeftWheelTransform;

    public  float motorForce=400f;
    public float steeringAngle = 30f;
    float VerticalInput;
    float HorizontalInput;
    [SerializeField] UiManager uiManager;

    public Transform  CenterOFMAss;
    public Rigidbody Rigidbody;

    void Start()
    {
        Rigidbody.centerOfMass=CenterOFMAss.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        Steering();
        ApplyBrakes();
        GEtInput();
        PowerSteering();
        Debug.Log(CarSpeed());
    }
    void GEtInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }
    void PowerSteering()
    {
        if (HorizontalInput == 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
        }
    }
    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FrontRightWheelCollider.brakeTorque = 1000f;
            BackRightWheelCollider.brakeTorque = 1000f;
            FrontLeftWheelCollider.brakeTorque = 1000f;
            BackLeftWheelCollider.brakeTorque = 1000f;
            Rigidbody.drag = 1f;
        }
        else
        {
            FrontRightWheelCollider.brakeTorque = 0f;
            BackRightWheelCollider.brakeTorque = 0f;
            FrontLeftWheelCollider.brakeTorque = 0f;
            BackLeftWheelCollider.brakeTorque = 0f;
            Rigidbody.drag = 0f;
        }
    }

    public float CarSpeed()
    {
        float speed = Rigidbody.velocity.magnitude * 2.23693629f;
        return speed;
    }

       
    void Steering()
    {
        FrontLeftWheelCollider.steerAngle = 30f * HorizontalInput;
        FrontRightWheelCollider.steerAngle = 30f * HorizontalInput;
    }
    void UpdateWheels()
    {
        RotateWheel(FrontLeftWheelCollider ,frontLeftWheelTransform);
        RotateWheel(FrontRightWheelCollider, frontRightWheelTransform);
        RotateWheel(BackLeftWheelCollider, backLeftWheelTransform);
        RotateWheel(BackRightWheelCollider, backRightWheelTransform);
    }
    void MotorForce()
    {
        FrontLeftWheelCollider.motorTorque = motorForce * VerticalInput;
        FrontRightWheelCollider.motorTorque = motorForce * VerticalInput;

    }
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Helo Collided");
        if (other.gameObject.tag =="TrafficVehicle" )
        {
             uiManager.GameOver();
            //Debug.Log("lol Collided");
            Time.timeScale = 0f;
        }
    }
    void RotateWheel(WheelCollider wheelcollider,Transform transform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelcollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }

}
