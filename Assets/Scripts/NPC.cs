using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject interaction;
    public GameObject quest;
    public Transform toonTrans;

    private float dist;
    public float maxDist = 2;

    public bool isNear = false;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (toonTrans != null)
        {
            dist = Vector3.Distance(toonTrans.position, transform.position);
            LookAt();
            PlayerSearch();
        }
    }

    private void LookAt()
    {
        if (dist <= maxDist)
        {
            Quaternion rotation = Quaternion.LookRotation(toonTrans.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
    }

    private void PlayerSearch()
    {
        Vector3 dirToToon = (toonTrans.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dirToToon);
        if (dist <= maxDist)
        {
            isNear = true;
        }
        else if (dist > maxDist)
        {
            isNear = false;
        }
    }
}
