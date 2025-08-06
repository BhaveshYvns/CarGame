using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] Lanes;
    [SerializeField] GameObject[] TrafficVehicles; 
    [SerializeField] CarMovement CarMovement;
    private float dyamicTimer = 2f;
    void Start()
    {
        StartCoroutine(TrafficSpawmer());
    }

    IEnumerator TrafficSpawmer()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            
            if (CarMovement.CarSpeed() > 20f)
            {
                dyamicTimer = Random.Range(30f, 60f) / CarMovement.CarSpeed();
                SpawnTrafficVehicle();
            }
            yield return new WaitForSeconds(2f);
        }
    }
    void SpawnTrafficVehicle()
    {
        int randomLaneIndex = Random.Range(0, Lanes.Length);
        int randomTrafficVehicle = Random.Range(0, TrafficVehicles.Length);
        Instantiate(TrafficVehicles[randomTrafficVehicle], Lanes[randomLaneIndex].position, Quaternion.identity);
    }
}
