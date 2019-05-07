using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    private Renderer r;
    private Vector2 offset;

    public float VertScrollSpeed = 1.0f;
    public float HorizScrollSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        offset = r.material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset -= new Vector2(HorizScrollSpeed * Time.deltaTime, VertScrollSpeed * Time.deltaTime);
        r.material.mainTextureOffset = offset;
    }
}
