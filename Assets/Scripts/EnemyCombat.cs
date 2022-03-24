using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] AudioClip laserShot;
    [SerializeField] [Range(0, 1)] float shotSoundVolume = 0.75f;
    [SerializeField] GameObject explosionVFX;

    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float explosionSoundVolume = 0.75f;

    [SerializeField] float health = 500f;
    [SerializeField] float fireSpeed = 20f;
    [SerializeField] float shotCounter;
    [SerializeField] float minShotingDelay, maxShotingDelay;
    [SerializeField] float explosionDuration = 0.5f;

    void Start()
    {
        shotCounter = Random.Range(minShotingDelay, maxShotingDelay);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShot();
    }

    private void CountDownAndShot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minShotingDelay, maxShotingDelay);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaserPrefab, transform.localPosition, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -fireSpeed);
        AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, shotSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        DamageReceiving(damageDealer);
    }

    private void DamageReceiving(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        //SetCoins();
        GameObject particlesExplosion = Instantiate(explosionVFX, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
        Destroy(particlesExplosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, explosionSoundVolume);

    }


    private int SetCoins()
    {

        return 1;
    }

}
