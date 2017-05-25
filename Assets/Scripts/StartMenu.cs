using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Credits;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnOption()
    {
        MainMenu.SetActive(false);
        Options.SetActive(true);
    }
    public void OnCredit()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }
   public  void OnReturn()
    {
        Credits.SetActive(false);
        Options.SetActive(false);
        MainMenu.SetActive(true);
    }
}
