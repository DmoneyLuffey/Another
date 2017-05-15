using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    KeyCode forward = KeyCode.W;
    KeyCode backward = KeyCode.S;
    KeyCode left = KeyCode.A;
    KeyCode right = KeyCode.D;

    private Rigidbody rb;

    public Slider healthSlider = null;
    public Text healthText;

    public float maxHealth = 100;
    public float health;

    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    private float healthStart = 0f;
    public float healthCoolDown = 2f;

    public bool hasRing = false;
    public bool isInCombat = false;
    public bool canRegenHealth = false;

    // Use this for initialization
    void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        //health = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMoves();
        /*healthText.text = "HP:" + health + "/" + maxHealth;
        healthSlider.value = health;
        healthSlider.maxValue = maxHealth;
        HealthRegen(5);*/
        
    }

    void PlayerMoves()
    {
        if (Input.GetKey(forward))
        {
            Vector3 movementDir = this.transform.forward;
            movementDir.Normalize();
            this.rb.MovePosition(this.transform.position + movementDir * (moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(backward))
        {
            Vector3 movementDir = this.transform.forward;
            movementDir.Normalize();
            this.rb.MovePosition(this.transform.position - movementDir * (moveSpeed * Time.deltaTime));
        }
        if (Input.GetKey(right))
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            transform.Rotate(Vector3.up * -turnSpeed * Time.deltaTime);
        }
    }

   /* public void HealthRegen(float amount)
    {
        if(health < maxHealth)
        {
            canRegenHealth = true;
        }
        else if(health > maxHealth)
        {
            canRegenHealth = false;
            health = maxHealth;
        }
        if (health < maxHealth && !isInCombat && canRegenHealth)
        {
            if (Time.time > healthStart + healthCoolDown)
            {
                healthStart = Time.time;
                health += amount;
                healthSlider.value = health;
            }
         }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ring")
        {
            hasRing = true;
            Destroy(other.gameObject);
        }
    }*/
}

