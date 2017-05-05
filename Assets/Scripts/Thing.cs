using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Thing : MonoBehaviour
{
    public KeyCode moveUpInput = KeyCode.UpArrow;
    public KeyCode moveDownInput = KeyCode.DownArrow;
    public KeyCode moveLeftInput = KeyCode.LeftArrow;
    public KeyCode moveRightInput = KeyCode.RightArrow;
    public KeyCode activateShield = KeyCode.LeftShift;

    public GameObject[] laserPlacements;
    public GameObject[] flarePlacements;
    public GameObject[] spaceMinePlacements;

    public GameObject[] thrusterPlacements;

    public GameObject laserPrefab = null;
    public GameObject flarePrefab = null;
    public GameObject flamePrefab = null;
    public GameObject minePrefab = null;
    public GameObject shieldPrefab = null;
    
    public GameObject flareMissile = null;

    public KeyCode fireLaser = KeyCode.Space;
    
    public KeyCode fireFlare = KeyCode.E;
    public bool canFireFlare = true;

    public KeyCode dropMine = KeyCode.M;
    public bool canDropMine = true;

    public float speed = 1.0f;

    public int flareAmmo = 10;

    public int mineAmmo = 3;

    public float timer = 0.0f;
    public float rateOfFire = 0.5f;

    public float laserTimer = 0.0f;
    public float laserRateOfFire = 0.5f;

    public int health = 100;

    public bool canPickUpHealth = false;
    public bool canPickUpHealthShield = false;
    public bool canPickUpMissile = false;
    public bool canPickUpMine = false;
    
    public Slider healthSlider = null;
    public Slider missileSlider = null;
    public Slider mineSlider = null;
   
    public bool canBeDamaged = true;

    public bool shieldActive = false;
    public bool shieldCanBeDamaged = false;
    public bool canUseShield = true;
    public int energy = 100;
    public Slider energySlider = null;

    public GameObject gameOver = null;

    public GameObject timers;

    public PlayerController playerController;

   /* public BigBoss bigBoss;

    public EnemySpawner spawner;
    public EnemySpawner spawner1;
    public EnemySpawner spawner2;
    public PowerUpSpawn powerUp;
    public GameObject reinforcements1 = null;
    public GameObject reinforcements2 = null;

    public Feeler frontFeeler = null;
    public Feeler backFeeler = null;
    public Feeler leftFeeler = null;
    public Feeler rightFeeler = null;

    // Use this for initialization
    void Start ()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUpInput) && frontFeeler.canMove == true)
            foreach (GameObject thrusterPlacement in thrusterPlacements)
            {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            Instantiate(flamePrefab, thrusterPlacement.transform.position, thrusterPlacement.transform.rotation);
            }
        if (Input.GetKey(moveDownInput) && backFeeler.canMove == true)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveLeftInput) && leftFeeler.canMove == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(moveRightInput) && rightFeeler.canMove == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(activateShield))
        {
            if(canUseShield == true)
            {
                canBeDamaged = false;
                shieldActive = true;
                shieldCanBeDamaged = true;
                shieldPrefab.SetActive(true);
            }
            
        }
        if(Input.GetKeyUp(activateShield))
        {
            shieldActive = false;
            shieldPrefab.SetActive(false);
            shieldCanBeDamaged = false;
            canBeDamaged = true;
        }

        if(flareAmmo <= 10)
        {
            canPickUpMissile = true;
        }
        if(flareAmmo >= 10)
        {
            canPickUpMissile = false;
            
        }
        if(flareAmmo <= 0)
        {
            canFireFlare = false;
        }
        if(flareAmmo > 0)
        {
            canFireFlare = true;
        }

        if(mineAmmo <= 3)
        {
            canPickUpMine = true;
        }
        if(mineAmmo >=3)
        {
            canPickUpMine = false;
        }
        if(mineAmmo <= 0)
        {
            canDropMine = false;
        }
        if(mineAmmo > 0)
        {
            canDropMine = true;
        }

        if (energy <= 0)
        {
            canPickUpHealthShield = true;
            canUseShield = false;
            shieldPrefab.SetActive(false);
        }
        if(energy > 0)
        {
            canPickUpHealthShield = true;
            canUseShield = true;
        }
        if(energy <= 150)
        {
            canPickUpHealthShield = true;
        }
        if(energy >= 150)
        {
            canPickUpHealthShield = false;
        }

        if (health < 150)
        {
            canPickUpHealth = true;
        }
        if(health >=100)
        {
            canPickUpHealth = false;
        }
        if(health <= 0)
        {
            gameObject.SetActive(false);
            bigBoss.enabled = false;
            playerController.enabled = false;
            spawner.enabled = false;
            spawner1.enabled = false;
            spawner2.enabled = false;
            powerUp.enabled = false;
            gameOver.SetActive(true);
            timers.SetActive(false);
            reinforcements1.SetActive(false);
            reinforcements2.SetActive(false);
        }

        HandleFire();
    }

    void HandleFire()
    {
        if(Input.GetKey(fireLaser))
        {
            for(int i = 0; i < 4; i++)
            {
                laserTimer += Time.deltaTime;
                if (laserTimer >= laserRateOfFire)
                {
                    Instantiate(laserPrefab, laserPlacements[i].transform.position, Quaternion.identity);
                    laserTimer = 0.0f;
                }
            }
        }
        if (Input.GetKey(fireFlare))
        {
            for (int i = 0; i < 4; i++)
            {
                timer += Time.deltaTime;
                if (timer >= rateOfFire)
                    if (canFireFlare == true)
                    {
                        Instantiate(flarePrefab, flarePlacements[i].transform.position, Quaternion.identity);
                        FlareAmmo(1);
                        timer = 0.0f;
                    }
            }
                
        }
        if(Input.GetKeyDown(dropMine))
        {
            for(int i = 0; i<1; i++)
                if(canDropMine == true)
                {
                    Instantiate(minePrefab, spaceMinePlacements[i].transform.position, Quaternion.identity);
                    MineAmmo(1);
                }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="EnemyLaser(Clone)")
        {
            if(canBeDamaged == true)
            {
                TakeDamage(5);
            }
            if(shieldActive == true)
            {
                TakeDamage(5);
            }
            
        }
        if(other.gameObject.name =="DiveBomber(Clone)")
        {
            if (canBeDamaged == true)
            {
                TakeDamage(5);
            }
            if (shieldActive == true)
            {
                TakeDamage(5);
            }
        }
        if (other.gameObject.name == "EnemyFlares(Clone)")
        {
            if (canBeDamaged == true)
            {
                TakeDamage(3);
            }
            if (shieldActive == true)
            {
                TakeDamage(3);
            }
        }
        if(other.gameObject.name == "MissilePowerUp(Clone)")
        {
            if(canPickUpMissile == true)
            {
                MissilePowerUp(5);
                Destroy(other.gameObject);
            }
        }
        if (other.gameObject.name == "HealthPowerUp(Clone)")
        {
            if (canPickUpHealth == true) 
            {
                HealthPowerUp(5);
                Destroy(other.gameObject);
            }
            if(canPickUpHealthShield == true)
            {
                EnergyPowerUp(10);
                Destroy(other.gameObject);
            }
        }
        if(other.gameObject.name == "MinePowerUp(Clone)")
        {
            if(canPickUpMine == true)
            {
                MinePowerUp(1);
                Destroy(other.gameObject);
            }
        }
    }

    public void FlareAmmo(int ammo)
    {
        flareAmmo -= ammo;
        missileSlider.value = flareAmmo;
    }
    public void MineAmmo(int ammo)
    {
        mineAmmo -= ammo;
        mineSlider.value = mineAmmo;
    }

    public void TakeDamage(int amount)
    {
        if (canBeDamaged == true)
        {
            health -= amount;
            healthSlider.value = health;
        }

        if (shieldCanBeDamaged == true)
        {
            energy -= amount;
            energySlider.value = energy;
        }
    }

    public void MissilePowerUp(int amount)
    {
        flareAmmo += amount;
        missileSlider.value = flareAmmo;
    }

    public void HealthPowerUp(int amount)
    {
        health += amount;
        healthSlider.value = health;

    }
    public void MinePowerUp(int amount)
    {
        mineAmmo += amount;
        mineSlider.value = mineAmmo;
    }
    public void EnergyPowerUp(int amount)
    {
        energy += amount;
        energySlider.value = energy;
    }*/
    
}
