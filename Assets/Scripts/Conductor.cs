using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public bool loop;
    [System.Serializable] public struct Actor {
        public GameObject gameObject;
        public Vector3 position;
        public float time;
    }
    public Actor[] actors;
    private int currActor;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        currActor = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (currActor >= actors.Length) {
            if (loop) {
                currActor = 0;
                time = 0;
            }
            else {
                this.gameObject.SetActive(true);
            }
        }
        else if (actors[currActor].time == -1) {
            if (currActor > 0 && !actors[currActor - 1].gameObject.activeInHierarchy) {
                Instantiate(actors[currActor].gameObject, actors[currActor].position, Quaternion.identity);
                currActor += 1;
            }
        }
        else if (time > actors[currActor].time) {
            Instantiate(actors[currActor].gameObject, actors[currActor].position, Quaternion.identity);
            currActor += 1;
        }
    }
}
