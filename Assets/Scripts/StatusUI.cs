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
    [HideInInspector] public int scoreCount;

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
        if (player == null) // if player doesn't exist, don't update the ui
            return;

        specialAttackAmmoCount = player.GetComponent<SpecialAttack>().ammo;
        damageBoostCount = player.GetComponent<ItemPickUp>().damageBoostCount;
        if (scoreCount < 0)
        {
            scoreCount = 0;
        }

        specialAttackAmmo.text = "x " + specialAttackAmmoCount;
        damageBoost.text = "x " + damageBoostCount;
        score.text = "x " + scoreCount;
    }
}
