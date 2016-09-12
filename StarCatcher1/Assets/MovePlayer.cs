using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

    //This is the character controller component
    private CharacterController myCC;
    //Temp var of datatype Vector3 to move the character
    private Vector3 tempPos;
    //Speed of the temp var in x
    public float speed = 1;
    public float gravity = 9.81f;
    public float jumpSpeed = 1;
    public int jumpCount = 0;
    public int jumpCountMax = 2;



	// Use this for initialization
	void Start ()
    {
        //This "finds" the character controller component
        myCC = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Waiting for input and comparing jumpCount.
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < jumpCountMax - 1)
        {
            //Incrementing the jumpCount by one.
            jumpCount++;
            //Adding the jumpSpeed var to the tempPos var.
            tempPos.y = jumpSpeed;
        }

        //Test if the charactercontroller is grounded.
        if(myCC.isGrounded)
        {
            //Reset the jumpCount if it is grounded.
            jumpCount = 0;
        }
       
        //Adding the gravity var to the y position of the tempPos var.
        tempPos.y -= gravity;
        //Adding the speed var to the tempPos var x value with the right and left arrow keys.
        tempPos.x = speed * Input.GetAxis("Horizontal");
        //Moves the charactercontroller at an even pace.
        myCC.Move(tempPos * Time.deltaTime);
      
	}
}
