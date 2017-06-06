using UnityEngine;
using System.Collections;

public class Thing : MonoBehaviour
{
    public GameObject enemies;
    public Enemy enemy;
    public Transform enemyRespawn;
    public Transform toonTrans;

    private float dist;
    public float maxDist = 2;
    public float distCheck = 10.0f;

    private float damageStart = 0f;
    public float damageCoolDown = 2.0f;

    // Use this for initialization
    void Start ()
    {
        enemies = this.gameObject;
        enemy = this.gameObject.GetComponent<Enemy>();
        toonTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        dist = Vector3.Distance(toonTrans.position, transform.position);
    }
    void OnMouseOver()
    {
        //print("Target Spotted");
        if(dist <= maxDist)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > damageStart + damageCoolDown)
                {
                    damageStart = Time.time;
                    enemy.currentHealth -= 1;
                }
                    
            }
        }
       
        
    }
}
