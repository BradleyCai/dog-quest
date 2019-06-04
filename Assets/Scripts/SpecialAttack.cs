using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public GameObject obj;

    private bool ready;

    public float delay;
    private float time;

    public int ammoMax;
    [HideInInspector] public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        ready = true;
        time = 0;
        ammo = ammoMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && ready && this.isActiveAndEnabled)
        {
            Instantiate(obj, this.GetComponent<Transform>());
            ready = false;
            time = 0;
            ammo--;
        }

        if (!ready && time >= delay && ammo > 0)
        {
            ready = true;
        }

        

        time += Time.deltaTime;

        
    }
}
