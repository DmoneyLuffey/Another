using UnityEngine;
using System.Collections;
using System;

public class Nothing : MonoBehaviour
{
    /*public Animator anim;
    public PlayerHealth playerHealth;
    public NavMeshAgent vampNav;
    public Transform toonTrans;
    private LayerMask crateLayer;
    public ParticleSystem bats;
    public GameObject vampModel;
    private Rigidbody rb;

    private float dist;
    public float maxDist = 2;
    public float distCheck = 10.0f;
    public float moveSpeed = 5.0f;
    private float damageStart = 0f;
    public float damageCoolDown = 2.0f;
    public float playerDamage = 1.0f;
    public float baseDamage = 1.0f;
    public float destroyTime = 0;

    public bool canAttackPlayer = false;
    public bool canAttackBase = false;
    public bool isAttacking = false;
    public bool isDistracted = false;
    public bool isDead = false;
    
    // Use this for initialization
    void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        anim.GetComponent<Animator>();
        vampNav = GetComponent<NavMeshAgent>();
        crateLayer = LayerMask.NameToLayer("Base");
        bats.enableEmission = false;
        playerHealth = GameManager.Instance.ToonRef.GetComponent<PlayerHealth>();
        toonTrans = GameManager.Instance.ToonRef.transform;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (toonTrans != null)
        {
			dist = Vector3.Distance(toonTrans.position, transform.position);
			PlayerSearch();
            LookAt();
        }
    }

	void FixedUpdate() {
		DayTimeDeath();
	}

    private void LookAt()
    {
        // Rotate to look at player.
        Quaternion rotation = Quaternion.LookRotation(toonTrans.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        //transform.LookAt(Target); alternate way to track player replaces both lines above.
    }

    private void PlayerSearch()
    {
        Vector3 dirToToon = (toonTrans.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dirToToon);
        if (Physics.Raycast(ray,distCheck, 1 << crateLayer))
        {
            isDistracted = true;
            if(isDistracted && !isDead && playerHealth.hasTurned == false)
            {
                canAttackBase = true;
                if(canAttackBase)
                {
                    isAttacking = true;
                    if (Time.time > damageStart + damageCoolDown)
                    {
                        if (isAttacking)
                        {
                            damageStart = Time.time;
                            GameManager.Instance.HomeBaseHealth -= baseDamage;
                            anim.SetTrigger("Attack");
                        }
                    }
                }
            }
        }
        else 
        {
            isDistracted = false;
            if (!isDistracted && dist <= maxDist && !isDead && playerHealth.hasTurned == false)
            {
                canAttackPlayer = true;
                if (canAttackPlayer)
                {
                    isAttacking = true;
                    if (Time.time > damageStart + damageCoolDown)
                    {
                        if (isAttacking)
                        {
                            damageStart = Time.time;
                            playerHealth.Damaged(playerDamage);
                            anim.SetTrigger("Attack");
                        }
                    }
                }
            }
            else if (!isDistracted && dist > maxDist && !isDead && playerHealth.hasTurned == false)
            {
                canAttackPlayer = false;
                if (!canAttackPlayer)
                {
                    isAttacking = false;
                    Vector3 movementDir = this.transform.forward;
                    movementDir.Normalize();
                    transform.LookAt(toonTrans);
                    this.rb.MovePosition(this.transform.position + movementDir * (moveSpeed * Time.deltaTime));
                    anim.SetTrigger("Walk");
                }
            }
        }
    }

    public void VampireDeath()
    {
        isDead = true;
        vampModel.SetActive(false);
        bats.enableEmission = true;
        Destroy(this.gameObject, 3);
    }

    public void DayTimeDeath()
    {
        if (!(GameManager.Instance.IsNight))
        {
            VampireDeath();
        }
    }*/
}

