using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    private GameObject game;
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;

    void Start() 
    {
        game = GameObject.Find("_GameManager");
    }

    async void FixedUpdate()
    {
        if (game.GetComponent<GameManager>().level2Clear) {
            if (Vector3.Distance(waypoints[currentWaypointIndex].transform.position, this.transform.position) < .1f) 
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            } 
            transform.position = Vector3.MoveTowards(this.transform.position, waypoints[currentWaypointIndex].transform.position, Time.fixedDeltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            col.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            col.gameObject.transform.SetParent(null);
        }
    }
}
