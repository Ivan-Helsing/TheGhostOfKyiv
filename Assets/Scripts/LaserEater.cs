using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEater : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObject(collision.gameObject);
    }



}
