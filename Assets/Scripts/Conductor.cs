using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public bool loop;
    [System.Serializable] public struct Actor {
        public GameObject gameObject;
        public Vector3 position;
        public float delay;
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
                Destroy(this.gameObject);
            }
        }
        else if (actors[currActor].delay == -1) {
            if (currActor > 0 && actors[currActor - 1].gameObject == null) {
                actors[currActor].gameObject = Instantiate(actors[currActor].gameObject, actors[currActor].position, Quaternion.identity);
                currActor++;
                time = 0;
            }
        }
        else if (time > actors[currActor].delay) {
            time = 0;
            actors[currActor].gameObject = Instantiate(actors[currActor].gameObject, actors[currActor].position, Quaternion.identity);
            currActor++;
        }
    }
}
