using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerUI : MonoBehaviour
{
    public string levelToLoad = "";

    Rect rect;

    public float currentHealth;
    private float health = 10;
    private Texture heartTexture;
    private float healthStart = 0f;
    public float healthCoolDown = 2f;
    public float healthDepletion = 1;

    public float currentHunger;
    private float hunger = 10;
    private Texture hungerTexture;
    private float hungerStart = 0f;
    public float hungerCoolDown = 2f;
    public float hungerDepletion = 1;

    public bool isStarving = false;
    public bool isDying = false;
    bool isDead = false;

    // Use this for initialization
    void Start ()
    {
        currentHunger = hunger;
        currentHealth = health;

        rect = new Rect(Screen.width*0.02f,Screen.height*0.95f,Screen.width*0.05f,Screen.width*0.05f); //Places Texture in Proper position
        heartTexture = Resources.Load("Images/Heart") as Texture; //Loads texture being used
        hungerTexture = Resources.Load("Images/Hunger") as Texture;
    }

    void Update()
    {
        PlayerHealth();
        PlayerHunger();
        HealthRegen();

        if(currentHealth == health)
        {
            isDying = false;
        }

        if(currentHealth == 0)
        {
            isDead = true;
            SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
        }
    }
	
	// Update is called once per frame
	void OnGUI ()
    {
        for(int i = 0;i<currentHealth;i++)
        {
            Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

            GUI.DrawTexture(new Rect(rect.x * (.9f * i + 15), rect.y - 60, 50, 18), heartTexture); //Draws textrues
        }

        for (int i = 0; i < currentHunger; i++)
        {
            Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions ray of textures
            
            GUI.DrawTexture(new Rect(rect.x * (.9f * i + 25), rect.y - 60, 50, 18), hungerTexture); //Draws textrues
        }
    }

    void PlayerHealth()
    {
        if (Time.time > healthStart + healthCoolDown)
        {
            if (isStarving && currentHealth != 0)
            {
                isDying = true;
                healthStart = Time.time;
                currentHealth -= healthDepletion;
            }
        }
    }

    void PlayerHunger()
    {
        if (Time.time > hungerStart + hungerCoolDown)
        {
            if (isStarving == false)
            {
                hungerStart = Time.time;
                currentHunger -= hungerDepletion;
            }
            if (currentHunger == 0)
            {
                isStarving = true;
            }
            else if (currentHunger > 0)
            {
                isStarving = false;
            }
        }
    }
    void HealthRegen()
    {
        if (isDying == true)
        {
            if (Time.time > healthStart + healthCoolDown)
            {
                if (!isStarving && currentHealth != health)
                {
                    healthStart = Time.time;
                    currentHealth += healthDepletion;
                }
            }
        }
    }
}
