using UnityEngine;
using System.Collections;

public class Iron : MonoBehaviour
{
    public GameObject player;
    public GameObject childObj;
    private Vector3 aoe;
    private bool hold = false;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Sergei");
    }

    // Update is called once per frame
    void Update()
    {
        SetParent();
        Vector3 aoe = transform.TransformDirection(Vector3.one);
        DetachFromParent();
    }
    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag=="Sergei")
        {
            hold = true;
        }
        

    }
    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Sergei")
        {
            hold = false;
        }
    }
   
    public void SetParent()
    {
        if (Input.GetKeyDown(KeyCode.E) && hold && GameObject.FindWithTag("Sergei"))
        {
            print("HERP");
            childObj.transform.parent = player.transform;
        }
        
       // if (newParent.transform.parent != null) ;
    }
    public void DetachFromParent()
    {
        if (Input.GetKeyUp(KeyCode.E) && hold  &&GameObject.FindWithTag("Sergei"))
        {
            print("yes");
           childObj.transform.parent = null;
        }
    }
}
