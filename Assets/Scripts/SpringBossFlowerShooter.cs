using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBossFlowerShooter : MonoBehaviour
{
    private Transform player;

    private float waitTimeTeleport;
    private float waitTimeFire;
    //Note: Shooter's "attack rate" is 1 / (waitTimeTeleport + waitTimeFire)
    private bool hasTeleported;

    public GameObject[] gunSet;
    private bool gunSetActivated;

    private float time;

    public new GameObject particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            this.gameObject.SetActive(false);
            return;
        }

        DeactivateGunSet();
        gunSetActivated = false;

        waitTimeTeleport = this.GetComponentInParent<SpringBoss>().waitTimeTeleport;
        waitTimeFire = this.GetComponentInParent<SpringBoss>().waitTimeFire;
        SetAttackRate();

        hasTeleported = false;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= waitTimeTeleport && !hasTeleported)
        {
            this.gameObject.transform.position = player.position;
            hasTeleported = true;
            Instantiate(particleSystem, this.gameObject.transform);
        }

        if (time >= waitTimeTeleport + waitTimeFire)
        {
            time = 0;
            hasTeleported = false;

            if (!gunSetActivated)
            {
                ActivateGunSet();
            }
        }

        time += Time.deltaTime;
    }

    void DeactivateGunSet()
    {
        for (int i = 0; i < gunSet.Length; i++)
        {
            gunSet[i].GetComponent<Shooter>().enabled = false;
        }
        gunSetActivated = false;
    }

    void ActivateGunSet()
    {
        for (int i = 0; i < gunSet.Length; i++)
        {
            gunSet[i].GetComponent<Shooter>().enabled = true;
        }
        gunSetActivated = true;
    }

    void SetAttackRate()
    {
        for (int i = 0; i < gunSet.Length; i++)
        {
            gunSet[i].GetComponent<Shooter>().attackRate = 1 / (waitTimeTeleport + waitTimeFire);
        }
    }
}
