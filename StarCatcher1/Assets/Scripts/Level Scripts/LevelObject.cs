using UnityEngine;
using System.Collections;

public class LevelObject : MonoBehaviour
{
    private Vector3 newLocation;

	void OnTriggerEnter()
    {
        newLocation.x = StaticVars.nextSectionPosition;
        transform.position = newLocation;
        StaticVars.nextSectionPosition += StaticVars.distance;

    }
}
