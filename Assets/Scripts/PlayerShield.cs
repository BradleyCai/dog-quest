using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shield;
    public float duration;
    public float cooldownDuration;
    private float time;
    private bool onCooldown;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        onCooldown = false;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !onCooldown)
        {
            shield.SetActive(true);
            active = true;
            time = 0;
        }

        if (active && time >= duration)
        {
            shield.SetActive(false);
            active = false;
            onCooldown = true;
            time = 0;
        }

        if (onCooldown && time >= cooldownDuration)
        {
            onCooldown = false;
            time = 0;
        }

        time += Time.deltaTime;
    }
}
