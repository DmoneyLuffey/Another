using UnityEngine;
using System.Collections;

public class Thing : MonoBehaviour
{
    public GameObject enemies;
    public Enemy enemy;

    // Use this for initialization
    void Start ()
    {
        enemies = this.gameObject;
        enemy = this.gameObject.GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnMouseOver()
    {
        print("Target Spotted");
        if(Input.GetMouseButtonDown(0))
        {
            enemy.currentHealth -= 1;
        }
        
    }
}
