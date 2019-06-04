using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hitbox == null)
        {
            Destroy(this.gameObject);
        }
    }
}
