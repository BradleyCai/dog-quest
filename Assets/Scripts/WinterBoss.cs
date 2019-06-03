using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterBoss : MonoBehaviour
{
    private float phaseTime;
    public int[] phaseSequence;
    public float[] phaseTimeLimits;
    private int phaseCount;

    public int phase;

    public GameObject[] gunSet1;
    public GameObject[] gunSet2;

    private float time;

    private int rotationDirection;
    private float rotationSpeed;
    private float rotationTimer;
    private int rotationCounter;

    public int[] rotationDirections;
    public float[] rotationSpeeds;
    public float[] rotationSegmentDurations;
    
    

    public float rotationDirectionDuration;

    public BasicRotator rotator;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

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

    private void SetRotationDirection()
    {
        rotationDirection = rotationDirections[rotationCounter];
    }

    private void SetRotationSpeed()
    {
        rotationSpeed = rotationSpeeds[rotationCounter];
    }
}
