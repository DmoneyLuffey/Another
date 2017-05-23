using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourseUI : MonoBehaviour
{
    public GameObject vialHolder;
    public Text vialsText;

    public int vials;
    public float timeStart = 0f;
    public float timeDown = 2f;

    public bool pickedUp = false;

    // Use this for initialization
    void Start ()
    {
        vialsText.text = "Vials: " + vials.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.I))
        {
            vialHolder.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.I))
        {
            vialHolder.SetActive(false);
        }
        OnCollect();
    }

    public void OnCollect()
    {
        if(pickedUp)
        {
            vialHolder.SetActive(true);
            timeStart += Time.deltaTime;
            if (timeStart < timeDown + Time.deltaTime)
            {
                if (timeStart >= timeDown)
                {
                    timeStart = 0;
                    pickedUp = false;
                    vialHolder.SetActive(false);
                }
            }
        }
    }
}
