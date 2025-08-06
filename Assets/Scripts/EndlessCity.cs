using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessCity : MonoBehaviour
{
    [SerializeField] Transform playerCarTransform;
    [SerializeField] Transform otherRoadTransform;
    [SerializeField] float halfLength; // Half of the tile length

    void Update()
    {
        //float endOfThisTile = transform.position.z + halfLength;

        if (playerCarTransform.position.z > transform.position.z+halfLength+10)
        {
            transform.position = new Vector3(0, 0, otherRoadTransform.position.z + halfLength * 2);
        }
    }

}
