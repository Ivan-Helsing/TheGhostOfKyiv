using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [Header("Lead Gauge")]
    [SerializeField] GameObject smallBulletGauge;
    [SerializeField] GameObject middleRocketGauge;
    [SerializeField] GameObject hugeBombGauge;
    [SerializeField] AudioClip laserShot;
    [SerializeField] [Range(0, 1)] float shotSoundVolume = 0.75f;

    private GameObject enemyLaserPrefab;

    [Header("Die")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0,1)] float explosionSoundVolume = 0.75f;


    [Header ("Enemy Parameters")]
    [SerializeField] float health = 500f;
    [SerializeField] float fireSpeed = 20f;
    [SerializeField] float shotCounter;
    [SerializeField] float minShotingDelay, maxShotingDelay;
    [SerializeField] float explosionDuration = 0.5f;


    private bool isSmallEnemy;
    //private bool isMiddleEnemy;
    private bool isHugeEnemy;

    [Header("Coins Reward")]
    [SerializeField] int smallEnemyReward = 10;
    [SerializeField] int middleEnemyReward = 20;
    [SerializeField] int hugeEnemyReward = 30;

    public int coinsReward = 0;

    //public const string RewardedCoinsKey = "RewardedCoins";
    //private const int 0 = 0;


    [Header("Score Reward")]
    [SerializeField] float scoreMultiplier = 0.001f;
    

    void Start()
    {
        FireGauge();
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
        AudioSource.PlayClipAtPoint(laserShot, transform.position, shotSoundVolume);
    }

    private void FireGauge()
    {
        isSmallEnemy = gameObject.transform.localScale.x < .9f;
        isHugeEnemy = gameObject.transform.localScale.x > 1.1f;

        if (isSmallEnemy) { enemyLaserPrefab = smallBulletGauge; }
        else if (isHugeEnemy) { enemyLaserPrefab = hugeBombGauge; }
        else { enemyLaserPrefab = middleRocketGauge; }
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
        ExplosionEffect();
        AudioSource.PlayClipAtPoint(deathSFX, transform.position, explosionSoundVolume);
    }

    private void ExplosionEffect()
    {

        GameObject particlesExplosion = Instantiate(explosionVFX, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
        CoinsReward();
        Destroy(particlesExplosion, explosionDuration);
    }

    private void CoinsReward()
    {
        if (isSmallEnemy) { coinsReward = smallEnemyReward; }
        else if (isHugeEnemy) { coinsReward = hugeEnemyReward; }
        else { coinsReward = middleEnemyReward; }

        int rewarded = PlayerPrefs.GetInt(PlayGameUI.CurrentCoinsKey, 0);
        rewarded += coinsReward;
        PlayerPrefs.SetInt(PlayGameUI.CurrentCoinsKey, rewarded);

    }

}
