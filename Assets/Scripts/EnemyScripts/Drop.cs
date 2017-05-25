using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour
{
    public GameObject vials;
    public Enemy death;
    public Vector3 respawnLocation;
    public GameObject[] vialPlacements;

    public float minViles = 0.0f;
    public float maxViles = 10.0f;
    public float timer = 0.0f;
    public float rateOfFire = 0.5f;
    
    // Use this for initialization
    void Start ()
    {
        transform.position = this.transform.localPosition;
        death = this.GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        EnemyDeath();
	}

    public void EnemyDeath()
    {
        if (death.isDead)
        {
            if (Time.time > timer + rateOfFire)
            {
                if (death.waitingForRespawn)
                {
                    timer = Time.time;
                    float vileNum = Random.Range(minViles, maxViles);
                    for (int i = 0; i < vileNum; i++)
                    {
                        Instantiate(vials, respawnLocation, Quaternion.identity);
                        //timer = 0;
                    }
                }
                
            }
        }
    }
}
