using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public bool loop;
    [System.Serializable] public struct Actor {
        public GameObject gameObject;
        public Vector3 position;
        public float spawnDelay;
        public bool waitOnPrev;
    }
    public Actor[] actors;
    private int currActor;
    private float time;

    void Start()
    {
        currActor = 0;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (currActor >= actors.Length) {
            bool cleared = true;
            foreach (Actor actor in actors) {
                if (actor.gameObject != null)
                    cleared = false;
            }

            if (loop && cleared) {
                currActor = 0;
                time = 0;
            }
            else if (cleared) {
                Destroy(this.gameObject);
            }
        }
        else if (currActor > 0 && actors[currActor].waitOnPrev && actors[currActor - 1].gameObject != null) {
            time = 0;
        }
        else if (time > actors[currActor].spawnDelay) {
            time = 0;
            actors[currActor].gameObject = Instantiate(actors[currActor].gameObject, actors[currActor].position + transform.position, Quaternion.identity);
            currActor++;
        }
        // else if (actors[currActor].waitOnPrev) {
        //     if (currActor > 0 && actors[currActor - 1].gameObject == null) {
                
        //     }
        // }
        // else if (time > actors[currActor].spawnDelay) {
        //     time = 0;
        //     actors[currActor].gameObject = Instantiate(actors[currActor].gameObject, actors[currActor].position + transform.position, Quaternion.identity);
        //     currActor++;
        // }
    }
}
