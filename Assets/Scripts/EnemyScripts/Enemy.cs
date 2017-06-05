using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public string attackAnim = "";
    public string standAnim = "";
    public string runAnim = "";
    public Animator anim;
    public PlayerHealth playerHealth;
    public Transform enemyRespawn;
    public Transform toonTrans;
    private Rigidbody rb;

    public Vector3 respawnLocation; //the location at which the enemy respawns
    public Vector3 respawnRotation;

    public float currentHealth;
    private float health = 10;
    private float dist;
    public float maxDist = 2;
    public float distCheck = 10.0f;
    public float moveSpeed = 5.0f;
    private float damageStart = 0f;
    public float damageCoolDown = 2.0f;
    public float playerDamage = 1.0f;

    private float respawnStart = 0;
    public float respawnCoolDown = 3;
    public bool waitingForRespawn = false;

    public bool canAttack = false;
    public bool isAttacking = true;
    private bool isNear = false;
    public bool isDead = false;

    public bool canRun = true;
    public bool isRunning = false;

    // Use this for initialization
    void Start()
    {
        isDead = false;
        currentHealth = health;
        rb = this.GetComponent<Rigidbody>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        toonTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        respawnLocation = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (toonTrans != null)
        {
            dist = Vector3.Distance(toonTrans.position, transform.position);
            PlayerSearch();
            LookAt();
            EnemyDeath();
        }
    }
    private void LookAt()
    {
        if(dist <= maxDist)
        {
            Quaternion rotation = Quaternion.LookRotation(toonTrans.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
    }
    private void PlayerSearch()
    {
        Vector3 dirToToon = (toonTrans.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dirToToon);
        if (dist < maxDist && canRun)
        {
            if(isRunning)
            {
                
                isNear = true;
                Vector3 movementDir = this.transform.forward;
                movementDir.Normalize();
                transform.LookAt(toonTrans);
                this.rb.MovePosition(this.transform.position + movementDir * (moveSpeed * Time.deltaTime));
                
            }
            
        }

        if(canRun)
        {
            isRunning = true;
            if(isRunning)
            {
                anim.SetTrigger(runAnim);
            }
        }
        
        if (dist <= 1.5 && !isDead)
        {
            canRun = false;
            canAttack = true;
            if (canAttack)
            {
                anim.SetTrigger(attackAnim);
                isAttacking = true;
                //anim.SetTrigger(attackAnim);
                //Debug.Log("Hey, I'm hitting you.");
                DamagePlayer(playerDamage);
            }
        }
        if (dist > 1.5 && isNear)
        {
            canRun = true;
            canAttack = false;
            if(!canAttack)
            {
                isAttacking = false;
                if(!isAttacking)
                {
                    playerHealth.isHit = false;
                }
            }
        }
        if(dist > maxDist)
        {
            isRunning = false;
            canRun = true;
            //anim.SetTrigger(standAnim);
            isNear = false;
        }
    }

    public void DamagePlayer(float playerDamage)
    {
        if(canAttack && isAttacking)
        {
            isRunning = false;
            if (Time.time > damageStart + damageCoolDown)
            {
                
                if (isAttacking)
                {
                    
                    playerHealth.isHit = true;
                    damageStart = Time.time;
                    playerHealth.Damage(playerDamage);
                    

                }
            }
        }
    }
    public void EnemyDeath()
    {
        if(currentHealth <= 0)
        {
            transform.position = transform.position + Vector3.up * 1000; //just need to put him some place off screen
            isDead = true;
            waitingForRespawn = true;
        }

        if (waitingForRespawn)
        {
            respawnStart += Time.deltaTime;
            if (respawnStart >= respawnCoolDown)
            {
                isDead = false;
                Respawn();
                waitingForRespawn = false;
                currentHealth = health;
                respawnStart = 0;
            }
        }
    }

    public void Respawn()
    {
        transform.position = respawnLocation;
        //transform.rotation = respawnRotation;
    }
}
