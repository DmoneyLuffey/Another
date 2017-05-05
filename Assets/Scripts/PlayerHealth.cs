using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    Rect rect;

    public float currentHealth;
    private float health = 10;
    private Texture heartTexture;
    public float healthStart = 0f;
    public float coolDown = 2f;
    public float healthDepletion = 1;

    public bool isAttacked = false;
    public bool isHit = false;

    // Use this for initialization
    void Start ()
    {
        currentHealth = health;

        rect = new Rect(Screen.width * 0.005f, Screen.height * 0.25f, Screen.width * 0.05f, Screen.width * 0.05f); //Places Texture in Proper position
        heartTexture = Resources.Load("Images/TemporaryHealthImage") as Texture; //Loads texture being used
    }
	
	// Update is called once per frame
	void Update ()
    {
        Damage();
    }

    void OnGUI()
    {
        if(isAttacked)
        {
            for (int i = 0; i < currentHealth; i++)
            {
                Rect newRect = new Rect(rect.x, rect.y, rect.width, rect.width); //Positions array of textures

                GUI.DrawTexture(new Rect(rect.x * (.9f * i + 15), rect.y - 60, 50, 18), heartTexture); //Draws textrues
            }
        }
    }

    public void Damage()
    {
        if(isHit)
        {
            isAttacked = true;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isHit = true;
            currentHealth -= healthDepletion;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isHit = false;
        }

        if(isAttacked && !isHit)
        {
            healthStart += Time.deltaTime;
            if (healthStart < coolDown + Time.deltaTime)
            {
                if(healthStart >= coolDown && !isHit)
                {
                    healthStart = 0;
                    isAttacked = false;
                }
            }
        }
    }
}
