using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    Rect rect;

    public Transform player;
    public GameObject death;
    public Transform repsawnPoint;
    public KeyCode reset = KeyCode.E;

    public Vector3 respawnLocation;

    public string levelToLoad = "";

    public float currentHealth;
    private float health = 10;
    private Texture heartTexture;
    private Texture emptyTexture;
    private float healthStart = 0f;
    public float healthCoolDown = 2f;
    private float damageStart = 0f;
    public float damageCoolDown = 2f;
    public float healthDepletion = 1;

    public bool isAttacked = false;
    public bool isHealing = false;
    public bool isHit = false;

    // Use this for initialization
    void Start ()
    {
        player = this.gameObject.GetComponent<Transform>();
        currentHealth = health;
        respawnLocation = repsawnPoint.transform.position;
        rect = new Rect(Screen.width * 0.015f, Screen.height * 0.15f, Screen.width * 0.015f, Screen.width * 0.05f); //Places Texture in Proper position
        heartTexture = Resources.Load("Images/Heart") as Texture; //Loads texture being used
        emptyTexture = Resources.Load("Images/EmptyHeart") as Texture;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Damage(0);
        Death();
        if(player.position.y < -55.3)
        {
            transform.position = respawnLocation;
        }
    }

    void OnGUI()
    {
        if(isAttacked)
        {
            for (int i = 0; i < currentHealth; i++)
            {
                Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

                GUI.DrawTexture(new Rect(rect.x * (3f * i + 1), rect.y - 100, 70, 60), heartTexture); //Draws textrues
            }
            for (int i = 0; i < 10; i++)
            {
                Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

                GUI.DrawTexture(new Rect(rect.x * (3f * i + 1), rect.y - 100, 70, 60), emptyTexture); //Draws textrues
            }
        }

        if (isHealing)
        {
            for (int i = 0; i < currentHealth; i++)
            {
                Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

                GUI.DrawTexture(new Rect(rect.x * (3f * i + 1), rect.y - 100, 70, 60), heartTexture); //Draws textrues
            }
            for (int i = 0; i < 10; i++)
            {
                Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

                GUI.DrawTexture(new Rect(rect.x * (3f * i + 1), rect.y - 100, 70, 60), emptyTexture); //Draws textrues
            }
        }

    }

    public void Damage(float amount)
    {
        if(isHit)
        {
            currentHealth -= amount;
            isAttacked = true;
        }

        if (isAttacked && !isHit)
        {
            damageStart += Time.deltaTime;
            if (damageStart < damageCoolDown + Time.deltaTime)
            {
                if(damageStart >= damageCoolDown && !isHit)
                {
                    damageStart = 0;
                    isAttacked = false;
                }
            }
        }
    }
    public void Heal(float amount)
    {
        if (isHealing)
        {
            currentHealth += amount;
            isAttacked = true;
        }

        if (isHealing)
        {
            healthStart += Time.deltaTime;
            if (healthStart < healthCoolDown + Time.deltaTime)
            {
                if (healthStart >= healthCoolDown && !isHealing)
                {
                    healthStart = 0;
                    isAttacked = false;
                }
            }
        }
    }

    public void Death()
    {
        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            death.SetActive(true);
            if(death.activeInHierarchy)
            {
                if(Input.GetKeyDown(reset))
                {
                    SceneManager.LoadScene(levelToLoad);
                }
            }
        }
    }
}
