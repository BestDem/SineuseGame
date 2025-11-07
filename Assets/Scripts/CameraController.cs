using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private ViewUpController playerr;
    void Awake()
    {
        playerr = FindFirstObjectByType<ViewUpController>();
        //playerr.TryGetComponent(out GameObject tra);
        //tra = player;
    }

    void Update()
    {
        transform.position = player.transform.position;
    }
}