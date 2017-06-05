using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Options;
    public GameObject Credits;

    public string startGame = "";

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnPlay()
    {
        SceneManager.LoadScene(startGame);
        Time.timeScale = 1;
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
