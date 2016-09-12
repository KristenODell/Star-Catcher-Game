using UnityEngine;
using System.Collections;

public class CharacterSlide : MonoBehaviour
{

    private CharacterController myCC;
    public int slideDuration = 20;
    public float slideTime = 0.01f;

    IEnumerator Slide ()
    {
        int i = 0;
        while (i < slideDuration)
        {
            i++;
            yield return new WaitForSeconds(slideTime);
            print("Sliding");
        }
        
    }

	// Use this for initialization
	void Start ()
    {
        myCC = GetComponent<CharacterController>();
        StartCoroutine(Slide());
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
