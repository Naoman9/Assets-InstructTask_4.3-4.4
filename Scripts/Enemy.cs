using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public GameObject bombPrefab;


    private void Start()
    {
        InvokeRepeating("Bomb", 2.0f, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
    void Bomb()
    {
        Instantiate(bombPrefab, player.transform.position + new Vector3(0, 2.0f, 0), player.transform.rotation);
    }   
}
