using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    Rect rect;

    public string levelToLoad = "";

    public float currentHealth;
    private float health = 10;
    private Texture heartTexture;
    private Texture emptyTexture;
    private float healthStart = 0f;
    public float coolDown = 2f;
    public float healthDepletion = 1;

    public bool isAttacked = false;
    public bool isHit = false;

    // Use this for initialization
    void Start ()
    {
        currentHealth = health;

        rect = new Rect(Screen.width * 0.015f, Screen.height * 0.15f, Screen.width * 0.015f, Screen.width * 0.05f); //Places Texture in Proper position
        heartTexture = Resources.Load("Images/Heart") as Texture; //Loads texture being used
        emptyTexture = Resources.Load("Images/EmptyHeart") as Texture;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Damage(0);
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
