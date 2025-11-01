using System;
using UnityEngine;

public class PlayAnimTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
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
            animator.SetTrigger("isPlay");
        }
    }
}
