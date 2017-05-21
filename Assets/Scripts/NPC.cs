using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject interaction;
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;
    
    public ResourseUI player;
    
    public Transform toonTrans;

    public KeyCode initiate = KeyCode.E;

    private float dist;
    public float maxDist = 2;
    public int vialsToAward;
    public int price;
   

    public bool isNear = false;
    public bool isActive = false;
    public bool completed = false;
    public bool hasApproached = false;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ResourseUI>();
        toonTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
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
        if (dist <= maxDist && !isActive && !completed)
        {
            hasApproached = true;
            isNear = true;
            interaction.SetActive(true);
            if (Input.GetKeyDown(initiate))
            {
                interaction.SetActive(false);
                line1.SetActive(true);
                isActive = true;
            }
        }
        if (dist > maxDist && !completed && hasApproached)
        {
            isNear = false;
            interaction.SetActive(false);
            line1.SetActive(false);
            line2.SetActive(false);
            line3.SetActive(false);
            line3.SetActive(false);
            isActive = false;
            player.vialHolder.SetActive(false);

            if(player.vials <= vialsToAward && !isNear && !completed)
            {
                player.vialsText.text = "Vials: " + player.vials.ToString();
                player.vials = player.vials = 0;
            }
         }
    }

    public void OnContinue()
    {
        player.vialHolder.SetActive(true);
        line1.SetActive(false);
        line2.SetActive(true);
    }

    public void Collect()
    {
        player.vials = player.vials + vialsToAward;
        player.vialsText.text = "Vials: " + player.vials.ToString();
        line2.SetActive(false);
        line3.SetActive(true);
    }
    public void BuyVials()
    {
        player.vials = player.vials - price;
        player.vialsText.text = "Vials: " + player.vials.ToString();
        line4.SetActive(true);
        line3.SetActive(false);
    }

    public void End()
    {
        completed = true;
        player.vialHolder.SetActive(false);
        line4.SetActive(false);
    }
}
