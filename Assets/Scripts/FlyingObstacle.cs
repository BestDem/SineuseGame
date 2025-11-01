using UnityEngine;
using System;

public class FlyingObstacle : MonoBehaviour
{
    [SerializeField] private float speedFly;
    [SerializeField] private float distance;
    private GameObject player;
    private float position;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Math.Abs(transform.position.x - player.transform.position.x) <= distance)
        {
            position += speedFly * Time.deltaTime;

            transform.position = new Vector3(position, transform.position.y, transform.position.z);
        }
    }
}
