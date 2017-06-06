using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{
    public GameObject rock;
    public GameObject Wall;
    public bool pressed = false;

	// Use this for initialization
	void Start ()
    {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            Destroy(Wall);
        }
    }

    void OnTriggerEnter(Collider rock)
    {
        pressed = true;
    }
}
