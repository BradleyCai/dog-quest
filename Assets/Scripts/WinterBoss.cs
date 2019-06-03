using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBoss : MonoBehaviour
{
    [Header("Phase Settings")]
    public int[] phaseSequence;
    public float[] phaseTimeLimits;
    private int phaseCount;
    private float phaseTime;

    public int phase;

    [Header("Gun Sets")]
    public GameObject[] gunSet1;
    public GameObject[] gunSet2;
    public GameObject[] gunSet3;

    private float time;

    
    private int rotationDirection;
    private float rotationSpeed;
    private float rotationTimer;
    private int rotationCounter;

    [Header("Rotation Settings")]
    public int[] rotationDirections;
    public float[] rotationSpeeds;
    public float[] rotationSegmentDurations;

    public float rotationDirectionDuration;
    public BasicRotator rotator;

    
    private bool onOffSet2;
    private float set2Time;
    private bool onOffSet3;
    private float set3Time;

    [Header("On & Off")]
    public float set2OnDuration;
    public float set2OffDuration;
    public float set3OnDuration;
    public float set3OffDuration;

   
    

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        set2Time = 0;
        set3Time = 0;

        phaseTime = 0.0f;
        phaseCount = 0;
        phase = phaseSequence[phaseCount];

        ActivateSet1();
        DeactivateSet2();

        if (rotationDirections.Length > 0)
        {
            rotationDirection = rotationDirections[0];
        }

        if (rotationSpeeds.Length > 0)
        {
            rotationSpeed = rotationSpeeds[0];
        }

        rotationTimer = 0;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (rotationTimer >= rotationSegmentDurations[rotationCounter])
        {
            rotationTimer = 0;
            rotationCounter++;
            if (rotationCounter >= rotationSegmentDurations.Length)
            {
                rotationCounter = 0;
            }
            SetRotationDirection();
            SetRotationSpeed();
            rotator.angularSpeed = rotationSpeed * rotationDirection;
        }
        rotationTimer += Time.deltaTime;

        // Next: OnOff weapons system
        // Sets 2 and 3 will turn off and on at random, and the model of the boss will move to different locations to make it harder to hit
        if (onOffSet2 && set2Time >= set2OnDuration)
        {
            DeactivateSet2();
            onOffSet2 = false;
            set2Time = 0;
        }
        else if (!onOffSet2 && set2Time >= set2OffDuration)
        {
            ActivateSet2();
            onOffSet2 = true;
            set2Time = 0;
        }

        if (onOffSet3 && set3Time >= set3OnDuration)
        {
            DeactivateSet3();
            onOffSet3 = false;
            set3Time = 0;
        }
        else if (!onOffSet3 && set3Time >= set3OffDuration)
        {
            ActivateSet3();
            onOffSet3 = true;
            set3Time = 0;
        }
        set2Time += Time.deltaTime;
        set3Time += Time.deltaTime;

        time += Time.deltaTime;
        /*
        if (phaseTime >= phaseTimeLimits[phaseCount]) { }
        {
            phaseTime = 0;
            phaseCount += 1;
            switch (phase)
            {
                case 0:
                    phase = phaseSequence[phaseCount];
                    break;
                case 1:
                    DeactivateSet2();
                    ActivateSet1();
                    break;
                case 2:
                    DeactivateSet1();
                    ActivateSet2();
                    break;
                case 3:
                    ActivateSet1();
                    ActivateSet2();
                    break;
                default:
                    break;
            }

            phase = phaseSequence[phaseCount];
        }
        
        phaseTime += Time.deltaTime;
        */
    }
  
    private void ActivateSet1()
    {
        for (int i = 0; i < gunSet1.Length; i++)
        {
            gunSet1[i].GetComponent<Shooter>().enabled = true;
        }
    }

    private void DeactivateSet1()
    {
        for (int i = 0; i < gunSet1.Length; i++)
        {
            gunSet1[i].GetComponent<Shooter>().enabled = false;
        }
    }

    private void ActivateSet2()
    {
        for (int i = 0; i < gunSet2.Length; i++)
        {
            gunSet2[i].GetComponent<Shooter>().enabled = true;
        }
    }

    private void DeactivateSet2()
    {
        for (int i = 0; i < gunSet2.Length; i++)
        {
            gunSet2[i].GetComponent<Shooter>().enabled = false;
        }
    }

    private void ActivateSet3()
    {
        for (int i = 0; i < gunSet3.Length; i++)
        {
            gunSet3[i].GetComponent<Shooter>().enabled = true;
        }
    }

    private void DeactivateSet3()
    {
        for (int i = 0; i < gunSet3.Length; i++)
        {
            gunSet3[i].GetComponent<Shooter>().enabled = false;
        }
    }

    private void SetRotationDirection()
    {
        rotationDirection = rotationDirections[rotationCounter];
    }

    private void SetRotationSpeed()
    {
        rotationSpeed = rotationSpeeds[rotationCounter];
    }
}
