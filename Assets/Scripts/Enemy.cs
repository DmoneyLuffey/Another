using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Transform toonTrans;
    private Rigidbody rb;

    public float dist;
    public float maxDist = 2;
    public float distCheck = 10.0f;
    public float moveSpeed = 5.0f;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //crateLayer = LayerMask.NameToLayer("Base");
        //playerHealth = GetComponent<PlayerHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        if (toonTrans != null)
        {
            dist = Vector3.Distance(toonTrans.position, transform.position);
            PlayerSearch();
            LookAt();
        }
    }
    private void LookAt()
    {
        // Rotate to look at player.
        if(dist <= maxDist)
        {
            Quaternion rotation = Quaternion.LookRotation(toonTrans.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        
        //transform.LookAt(Target); alternate way to track player replaces both lines above.
    }
    private void PlayerSearch()
    {
        Vector3 dirToToon = (toonTrans.transform.position - this.transform.position).normalized;
        Ray ray = new Ray(this.transform.position, dirToToon);
        if (dist <= maxDist)
        {
            Vector3 movementDir = this.transform.forward;
            movementDir.Normalize();
            transform.LookAt(toonTrans);
            this.rb.MovePosition(this.transform.position + movementDir * (moveSpeed * Time.deltaTime));
        }
    }
}
