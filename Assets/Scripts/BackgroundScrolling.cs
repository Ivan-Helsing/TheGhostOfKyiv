using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 0.05f;


    Material backgroundMaterial;
    Vector2 offSet;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        backgroundMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
