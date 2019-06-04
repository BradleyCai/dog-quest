using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerBoss : MonoBehaviour
{
    public int phase;
    private int phaseCount;
    private float time;
    public int[] phaseSequence;
    public float[] phaseTimers;

    private Vector3 prevLocation;
    private Vector3 nextLocation;
    public Vector3[] phaseLocations;
    private int locationCount;

    public GameObject[] sets;

    

    private float angularSpeed;

    public GameObject model; // should be SummerBossModel

    // Start is called before the first frame update
    void Start()
    {
        phase = phaseSequence[phaseCount];
        phaseCount = 0;

        for (int i = 0; i < sets.Length; i++)
        {
            DeactivateSet(i);
        }

        angularSpeed = model.GetComponent<BasicRotator>().angularSpeed;

        prevLocation = new Vector3(-5 / 3, 0, 0);
        nextLocation = new Vector3(-4.33f, 4, 0);
        locationCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 4 phases: transition, top left, top right, middle
        if (time >= phaseTimers[phaseCount])
        {
            phaseCount++;
            if (phaseCount >= phaseSequence.Length)
            {
                phaseCount = 0;
            }
            phase = phaseSequence[phaseCount];
            
            switch (phase)
            {
                case 0:
                    for (int i = 0; i < sets.Length; i++)
                    {
                        DeactivateSet(i);
                    }
                    break;
                case 1:
                    prevLocation = nextLocation;
                    nextLocation = phaseLocations[2];
                    model.GetComponent<BasicRotator>().angularSpeed = angularSpeed;
                    ActivateSet(0);
                    ActivateSet(1);
                    DeactivateSet(2);
                    DeactivateSet(3);
                    DeactivateSet(4);
                    break;
                case 2:
                    prevLocation = nextLocation;
                    nextLocation = phaseLocations[0];
                    model.GetComponent<BasicRotator>().angularSpeed = angularSpeed * -1;
                    ActivateSet(0);
                    ActivateSet(1);
                    DeactivateSet(2);
                    DeactivateSet(3);
                    DeactivateSet(4);
                    break;
                case 3:
                    prevLocation = nextLocation;
                    nextLocation = phaseLocations[1];
                    model.GetComponent<BasicRotator>().angularSpeed = angularSpeed;
                    ActivateSet(2);
                    ActivateSet(3);
                    ActivateSet(4);
                    DeactivateSet(0);
                    DeactivateSet(1);
                    break;
                default:
                    for (int i = 0; i < sets.Length; i++)
                    {
                        ActivateSet(i);
                    }
                    break;
            }
            time = 0;
        }

        switch(phase)
        {
            case 0:
                transform.position = Vector3.Lerp(prevLocation, nextLocation, time/phaseTimers[phaseCount]);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }

        time += Time.deltaTime;
    }

    private void ActivateSet(int num)
    {
        foreach (Shooter shooter in sets[num].GetComponentsInChildren<Shooter>())
        {
            shooter.enabled = true;
        }
    }

    private void DeactivateSet(int num)
    {
        foreach (Shooter shooter in sets[num].GetComponentsInChildren<Shooter>())
        {
            shooter.enabled = false;
        }
    }
}
