using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Fondo : MonoBehaviour
{


    Material mt;
    public float parallax = 2f;
    Vector2 offset;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        mt = sp.material;
        cam = Camera.main.transform;
        offset = mt.mainTextureOffset;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = cam.position.x / transform.localScale.x / parallax;
        offset.y = cam.position.y / transform.localScale.y / parallax;

        mt.mainTextureOffset = offset;
    }
}
