﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int interval;
    // Update is called once per frame
    void Update()
    {
        interval += 1;

        if(interval%60==0)//余りが０の時
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position,Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();
            enemyShellRb = enemyShell.GetComponent<Rigidbody>();
            enemyShellRb.AddForce(transform.forward * shotSpeed);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
            Destroy(enemyShell, 3.0f);
        }
    }
}