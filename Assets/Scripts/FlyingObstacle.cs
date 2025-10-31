using UnityEngine;
using System;

public class FlyingObstacle : MonoBehaviour
{
    [SerializeField] private float distance;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - player.transform.position.x) <= distance)
        {

        }
    }
}
