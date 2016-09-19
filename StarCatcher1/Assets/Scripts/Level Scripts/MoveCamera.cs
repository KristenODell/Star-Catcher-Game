using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public float speed = 1;
    private Vector3 tempPos;


	void Update ()
    {
        tempPos.x = speed * Time.deltaTime;
        transform.Translate(tempPos);
	}
}
