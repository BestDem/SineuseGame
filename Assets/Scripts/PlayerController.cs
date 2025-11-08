using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Awake()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 6 && !GameManager.isShifting)
        {
            DeathMenuOn();
        }
    }

    private void DeathMenuOn()
    {
        GameManager.TriggerDeath();
        //deathMenu.SetActive(true);
        Time.timeScale = 0;
        GameManager.isPauseDeath = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenuDeath()
    {
        //deathMenu.SetActive(false);
        Time.timeScale = 1;
        GameManager.isPauseDeath = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnEnterCollision(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            DeathMenuOn();
        }
    }
}
