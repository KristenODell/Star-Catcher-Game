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
    //Sliding vars
    public int slideDuration = 100;
    public float slideTime = 0.1f;
    //Coroutine for sliding the character. Coroutines are IEnumerators.
    IEnumerator Slide ()
    {
        //Set a temp var to the value of slideDuration
        int durationTemp = slideDuration;
        //
        float speedTemp = speed;
        speed += speed;
        //While loop runs "while" the slide duration is greater than 0.
        while (slideDuration > 0)
        {
            //Decrement the slideDuration
            slideDuration--;
            //Yield "holds the coroutine"
            //Return "sends" to the coroutine to do an operation while yielding
            //New creates an instance of an object
            //WaitForSeconds is an object that waits for a duration of time
            yield return new WaitForSeconds(slideTime);
            
        }
        speed = speedTemp;
        slideDuration = durationTemp;
    }


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
        //Start sliding
        if(Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.S))
        {
            //StartCoroutine is a function that calls a coroutine. Use the coroutine in the argument.
            StartCoroutine(Slide());
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.S))
        {
            //StartCoroutine is a function that calls a coroutine. Use the coroutine in the argument.
            StartCoroutine(Slide());
        }

        //Test if the charactercontroller is grounded.
        if (myCC.isGrounded)
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
