using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    Controls controls;

    bool canShoot = true;
    bool isShooting;

    float shootCountdown;

    public Transform bulletSpawn;

    public GameObject rotateObject;

    public GunData activeGun;

    public GameObject bullet;


    private void Awake()
    {
        canShoot = true;
        controls = new Controls();
    }

    private void Update()
    {
        if (isShooting)
        {
            float timeTillBullet = shootCountdown -= Time.deltaTime;
            if(timeTillBullet <= 0)
            {
                //Shoot
                DetermineDirection();
                shootCountdown = activeGun.shootDelay;
            }
        }
    }
    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Started Shooting");
            isShooting = true;
        }

        if (ctx.canceled)
        {
            Debug.Log("Ended Shooting");
            isShooting = false;
        }
    }

    private void DetermineDirection()
    {
        float z = rotateObject.transform.rotation.eulerAngles.z;
        Vector2 shootDirection = Quaternion.Euler(0, 0, z) * Vector2.up;

        FireBullet(shootDirection);
    }

    private void FireBullet(Vector2 direction)
    {
        if (!canShoot)
            return;

        GameObject b = Instantiate(bullet, bulletSpawn.position,transform.rotation);
        b.GetComponent<Rigidbody2D>().velocity = direction * activeGun.bulletSpeed;
        b.GetComponent<Bullet>().damage = activeGun.damage;
        Destroy(b, activeGun.bulletTime);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
