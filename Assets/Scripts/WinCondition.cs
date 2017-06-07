using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinCondition : MonoBehaviour
{
    public KeyCode loadLevel = KeyCode.E;
    public GameObject congratulations;
    public string levelToLoad = "";

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(congratulations.activeInHierarchy)
        {
            if(Input.GetKeyDown(loadLevel))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sergei")
        {
            congratulations.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
