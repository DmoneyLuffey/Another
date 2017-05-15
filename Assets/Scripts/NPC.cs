using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject interaction;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public Transform toonTrans;

    public KeyCode initiate = KeyCode.E;

    private float dist;
    public float maxDist = 2;

    public bool isNear = false;
    public bool isActive = false;
    public bool canDisplay = false;

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

    public void PlayerSearch()
    {
        Vector3 dirToToon = (toonTrans.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dirToToon);
        if (dist <= maxDist && !isActive)
        {
            interaction.SetActive(true);
            if (Input.GetKeyDown(initiate))
            {
                interaction.SetActive(false);
                line1.SetActive(true);
                isActive = true;
            }
        }
        if (dist > maxDist)
        {
            interaction.SetActive(false);
            line1.SetActive(false);
            line2.SetActive(false);
            isActive = false;
         }
    }

    public void OnContinue()
    {
        line1.SetActive(false);
        line2.SetActive(true);
    }

    public void Collect()
    {

    }
}
