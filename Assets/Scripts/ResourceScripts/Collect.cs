using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Collect : MonoBehaviour
{
    public PlayerHealth playerHealth;
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
        playerHealth = GameObject.FindGameObjectWithTag("Sergei").GetComponent<PlayerHealth>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        playerUI = GameObject.FindGameObjectWithTag("Sergei").GetComponent<ResourseUI>();
        player = GameObject.FindGameObjectWithTag("Sergei");
        target = GameObject.FindWithTag("Sergei").transform;
        thisTransform = this.gameObject.transform;
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
        if(other.gameObject.tag == "Sergei")
        {
            playerUI.pickedUp = true;
            playerUI.vials = playerUI.vials + vialAmount;
            playerUI.vialsText.text = "Vials: " + playerUI.vials.ToString();
            
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Sergei")
        {
            if(this.gameObject.tag == "Health")
            {

                playerHealth.isHealing = true;
                playerHealth.currentHealth = 10;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(gameObject.tag == "Sergei")
        {
            playerHealth.isHealing = false;
        }
    }
}
