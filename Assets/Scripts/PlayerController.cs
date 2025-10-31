using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject deathMenu;
    public bool isDead = false;
    void Start()
    {
        
    }

    void Update()
    {
        
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
        deathMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void CloseMenuDeath()
    {
        deathMenu.SetActive(false);
        Time.timeScale = 0;
        Cursor.visible = false;
        isDead = true;
    }
}
