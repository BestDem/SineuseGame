using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            isDead = true;
        }
    }
}
