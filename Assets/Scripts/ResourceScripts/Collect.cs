using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collect : MonoBehaviour
{
    public GameObject player;

    public ResourseUI playerUI;

    public int vialAmount;

    // Use this for initialization
    void Start ()
    {
        playerUI = GameObject.FindGameObjectWithTag("Player").GetComponent<ResourseUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerUI.pickedUp = true;
            playerUI.vials = playerUI.vials + vialAmount;
            playerUI.vialsText.text = "Vials: " + playerUI.vials.ToString();
            print("Hello");
        }
    }
}
