using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserShot;
    [SerializeField] [Range(0, 1)] float shotSoundVolume = 0.75f;

    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float explosionSoundVolume = 0.75f;

    [SerializeField] float speed = 10f;
    [SerializeField] float fireSpeed = 20f;
    [SerializeField] float fireDelay = 0.1f;
    [SerializeField] float explosionDuration = 0.5f;

    [SerializeField] float health = 500f;
    [SerializeField] int hearts = 3;

    private int leftSide;
    private int rightSide;
    private int sideToFly;
    private float currentHealth;

    BoxCollider2D aircraftCollider2D;




    [Header("Player Settings")]
    [SerializeField] Sprite newSprite;


    void Start()
    {
        PlayerSpriteReplace();
        aircraftCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(LazerShooting());
        currentHealth = health;
    }

    void Update()
    {
        MoveAircraft();
    }


    private void PlayerSpriteReplace()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        DamageReceiving(damageDealer);
    }

    private void DamageReceiving(DamageDealer damageDealer)
    {
        currentHealth -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (currentHealth <= 0)
        {
            hearts -= 1;
            if (hearts <= 0)
            {
                Death();
            }
            currentHealth = health;
        }
    }

    private void Death()
    {
        GameObject particlesExplosion = Instantiate(explosionVFX, transform.localPosition, Quaternion.identity);
        Destroy(gameObject);
        Destroy(particlesExplosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, explosionSoundVolume);
        SceneManager.LoadScene("StartMenuScene");
    }

    private IEnumerator LazerShooting()
    {
        
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
            AudioSource.PlayClipAtPoint(laserShot, Camera.main.transform.position, shotSoundVolume);
            yield return new WaitForSeconds(fireDelay);
        }
    }

    public void RocketLaunch()
    {
        Debug.Log("Rocket Launched");
    }

    private void MoveAircraft()
    {
        bool touchRight = aircraftCollider2D.IsTouchingLayers(LayerMask.GetMask("WallRight"));
        bool touchLeft = aircraftCollider2D.IsTouchingLayers(LayerMask.GetMask("WallLeft"));
        bool moveRight = rightSide > 0;
        bool moveLeft = leftSide > 0;


        if (!touchRight && !touchLeft)
        {
            transform.Translate(Vector3.right * sideToFly * speed * Time.deltaTime);
        }

        else if (touchRight && moveRight) { return; }
        else if (touchLeft && moveLeft) { return; }

        else if (touchLeft && moveRight)
        {
            transform.Translate(Vector3.right * rightSide * speed * Time.deltaTime);
        }
        else if (touchRight && moveLeft)
        {
            transform.Translate(Vector3.left * leftSide * speed * Time.deltaTime);
        }

        else { return; }
    }

    

    public void FlyRight(int value)
    {
        rightSide = value;
    }

    public void FlyLeft(int value)
    {
        leftSide = value;
    }

    public void Manoeuvre(int value)
    {
        sideToFly = value;
    }

    public int GetCurrentHearth () { return hearts;  }

    private void BoostFireDelay()
    {
        //
    }

}