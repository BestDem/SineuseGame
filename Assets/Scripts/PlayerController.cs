using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private GameObject deathMenu;
    private PauseUI pauseUI;
    public static event Action DeathAction;
    private bool isDead = false;

    private void Awake()
    {
        pauseUI = FindFirstObjectByType<PauseUI>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 6)
        {
            DeathMenuOn();
        }
    }

    private void DeathMenuOn()
    {
        //DeathAction?.Invoke();
        //deathMenu.SetActive(true);
        Time.timeScale = 0;
        pauseUI.isPauseDeath = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenuDeath()
    {
        //deathMenu.SetActive(false);
        Time.timeScale = 1;
        pauseUI.isPauseDeath = false;
        Cursor.visible = false;
        isDead = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool IsDead()
    {
        return isDead;
    }

    void OnEnterCollision(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            DeathMenuOn();
        }
    }
}
