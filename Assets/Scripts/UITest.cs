using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public GameObject inventoryUI = null;

    public Slider healthUI = null;
    public Slider hungerUI = null;
    public Slider thirstUI = null;

    public float maxHealth = 100.0f;
    public float currentHealth;

    public float maxHunger = 100.0f;
    private float currentHunger;

    public float maxThirst = 100.0f;
    private float currentThirst;

    public float drain = 5.0f; //Amount taken away from Thirst and Hunger
    public float healthDamage = 5; //Amount of damage player takes

    public bool isStarving = false;
    public bool isThirsty = false;
    public bool isDying = false;

    private float hungerStart = 0f;
    public float hungerCoolDown = 2f;

    private float healthStart = 0f;
    public float healthCoolDown = 2f;

    private float thirstStart = 0f;
    public float thirstCoolDown = 2f;

    #region Properties
    public float CurrentThirst { get { return currentThirst; } set { currentThirst = value; } }
    public float CurrentHunger { get { return currentHunger; } set { currentHunger = value; } }
    #endregion

    void Start()
    {
        inventoryUI.SetActive(false);
        inventoryUI.GetComponent<Canvas>().enabled = true;
        currentHealth = maxHealth;
        CurrentHunger = maxHunger;
        CurrentThirst = maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            inventoryUI.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            inventoryUI.SetActive(false);
        }

        if (currentHealth >= maxHealth)
        {
            isDying = false;
        }

        TakeDamage(healthDamage); //Amount of damage dealt to Player's health
        Hunger(drain); //Amount depleted of Hunger UI
        Thirst(drain); //Amount depleted of Thirst UI
        HealthRegen(healthDamage); //Amount regained to Player's Health
    }

    //Damage Taken from either Hunger, Thirst or both
    void TakeDamage(float amount)
    {
        if (Time.time > healthStart + healthCoolDown)
        {
            if (isStarving == true)
            {
                isDying = true;
                healthStart = Time.time;
                currentHealth -= amount;
                healthUI.value = currentHealth;
            }
            if (isThirsty == true)
            {
                isDying = true;
                healthStart = Time.time;
                currentHealth -= amount;
                healthUI.value = currentHealth;
            }
            else if (isStarving == true && isThirsty == true)
            {
                isDying = true;
                healthStart = Time.time;
                currentHealth -= amount;
                healthUI.value = currentHealth;
            }
        }
    }

    //Controlls Hunger SliderUI with timer
    void Hunger(float amount)
    {
        if (Time.time > hungerStart + hungerCoolDown)
        {
            if (isStarving == false)
            {
                hungerStart = Time.time;
                CurrentHunger -= amount;
                hungerUI.value = CurrentHunger;
            }
            if (CurrentHunger == 0)
            {
                isStarving = true;
            }
            else if (CurrentHunger > 0)
            {
                isStarving = false;
            }
        }
    }

    //How much Hunger is replenished when fruit is eaten
    public void Eat(float amount)
    {
        CurrentHunger += amount;
        hungerUI.value = CurrentHunger;
    }
    public void Drink(float amount)
    {
        CurrentThirst += amount;
        thirstUI.value = CurrentThirst;
    }

    //Controls Thirst SliderUI with timer
    public void Thirst(float amount)
    {
        if (Time.time > thirstStart + thirstCoolDown)
        {
            if (isThirsty == false)
            {
                thirstStart = Time.time;
                CurrentThirst -= amount;
                thirstUI.value = CurrentThirst;
            }
            if (CurrentThirst == 0)
            {
                isThirsty = true;
            }
            else if (CurrentThirst > 0)
            {
                isThirsty = false;
            }
        }
    }

    //Controls Health Regen
    public void HealthRegen(float amount)
    {
        if (isDying == true)
        {
            if (Time.time > healthStart + healthCoolDown)
            {
                if (isStarving == false && isThirsty == false)
                {
                    healthStart = Time.time;
                    currentHealth += amount;
                    healthUI.value = currentHealth;
                }
            }
        }
    }
}

