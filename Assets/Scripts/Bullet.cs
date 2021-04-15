using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _attackDamage=5;

    void Start()
    {
        Destroy(gameObject,4);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag=="Player")
            col.transform.GetComponent<Player>().Health -= _attackDamage;
        Destroy(gameObject);
    }
}
