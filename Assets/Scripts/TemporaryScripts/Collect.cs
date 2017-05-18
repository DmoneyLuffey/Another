using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Hello");
        }
    }
}
