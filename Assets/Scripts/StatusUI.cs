using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public GameObject player;

    public Text specialAttackAmmo;
    public Text damageBoost;
    public Text score;

    private int specialAttackAmmoCount;
    private int damageBoostCount;
    private int scoreCount;

    // Start is called before the first frame update
    void Start()
    {
        specialAttackAmmoCount = player.GetComponent<SpecialAttack>().ammo;
        damageBoostCount = 0;
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        specialAttackAmmoCount = player.GetComponent<SpecialAttack>().ammo;
        damageBoostCount = player.GetComponent<ItemPickUp>().damageBoostCount;
        //scoreCount = ???

        specialAttackAmmo.text = "x " + specialAttackAmmoCount;
        damageBoost.text = "x " + damageBoostCount;
        score.text = "x " + scoreCount;
    }
}
