using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourseUI : MonoBehaviour
{
    public GameObject vialHolder;
    public Text vialsText;
    public int vials;

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
    }
}
