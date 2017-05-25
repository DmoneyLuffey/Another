using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collect : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public ResourseUI playerUI;
    public Transform thisTransform;

    public int vialAmount;
    public float rotationSpeed;
    public float moveSpeed;

    public float minSpeed = 0;
    public float maxSpeed = 0;

    // Use this for initialization
    void Start ()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        playerUI = GameObject.FindGameObjectWithTag("Player").GetComponent<ResourseUI>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindWithTag("Player").transform;
        thisTransform = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation,
        Quaternion.LookRotation(target.position - thisTransform.position), rotationSpeed * Time.deltaTime);
        thisTransform.position += thisTransform.forward * moveSpeed * Time.deltaTime;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerUI.pickedUp = true;
            playerUI.vials = playerUI.vials + vialAmount;
            playerUI.vialsText.text = "Vials: " + playerUI.vials.ToString();
            print("Hello");
            Destroy(this.gameObject);
        }
    }
}
