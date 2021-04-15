using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public float bulletForce = 20f;

    public float FireTime;

    [SerializeField]
    private float randomness=.1f;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnGameStateChange+=InvokeShoot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvokeShoot()
    {
        if(GameManager.current.CurrentState==GameState.Game)
            InvokeRepeating("Shoot", FireTime, .75f);
        else
        {
            CancelInvoke();
        }
    }
    private void Shoot()
    {
        GameObject bullet=Instantiate(projectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(TargetRandomness(firePoint.up)*bulletForce,ForceMode2D.Impulse);
    }

    private Vector3 TargetRandomness(Vector3 point)
    {
        var position = new Vector3(UnityEngine.Random.Range(point.x-randomness, point.x+randomness), UnityEngine.Random.Range(point.y - randomness, point.y + randomness),firePoint.position.z);
        return position;
    }
}
