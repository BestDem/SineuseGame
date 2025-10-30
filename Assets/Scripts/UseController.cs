using UnityEngine;

public class UseController : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private float distationUse = 4;
    private float direction;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15f))
        {
            direction = Vector3.Distance(head.position, hit.transform.position);
            if (direction < distationUse)
            {
                if (hit.collider.TryGetComponent(out IUseble use))  //складывание предметов в инвентарь пкм
                {
                    //активация руки
                    if (Input.GetKeyDown(KeyCode.E))
                        use.Use();
                }
            }
            else
            {
                //деактивация руки
            }
        }    
    }
}
