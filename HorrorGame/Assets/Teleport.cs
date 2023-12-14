using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Teleport : MonoBehaviour
{
    public float teleportRange;
    public Vector3 lowerBoundaries, upperBoundaries;
    //when clicked, move to a random location
    private void OnMouseDown()
    {
        Vector3 newPos = transform.position;
        
        newPos += new Vector3(
            Random.Range(-teleportRange, teleportRange),
            Random.Range(-teleportRange, teleportRange),
            Random.Range(-teleportRange, teleportRange)
            );

        //Clamp the x,y,z to our boundary
        newPos.x = Mathf.Clamp(newPos.x, lowerBoundaries.x, upperBoundaries.x);
        newPos.y = Mathf.Clamp(newPos.y, lowerBoundaries.y, upperBoundaries.y);
        newPos.z = Mathf.Clamp(newPos.z, lowerBoundaries.z, upperBoundaries.z);
        
        transform.position = newPos;
    }
}
