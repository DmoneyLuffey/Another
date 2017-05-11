﻿using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public GameObject spawnPoint;
    public GameObject ExplosionPrefab;
    public Rigidbody projectilePrefab;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            Rigidbody hitPlayer;
            hitPlayer = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
            hitPlayer.velocity = transform.TransformDirection(Vector3.forward * 50);
            //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


        }


        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Rigidbody clone;
                clone = Instantiate(projectilePrefab, transform.position, transform.rotation) as Rigidbody;
                clone.velocity = transform.TransformDirection(Vector3.forward * 200);
                //            Physics.IgnoreCollision ( projectilePrefab.collider, transform.root.collider );


            }
        }



    }
}