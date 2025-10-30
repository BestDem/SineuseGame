using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Params")]
    [SerializeField] private float MouseSens = 0;

    [Header("Components")]
    [SerializeField] private InputController inputController;

    [Header("GameObjects")]
    [SerializeField] private GameObject headMove;
    private bool lockedCamera = true;
    private float _xRot = 0f;
    private int reviewCamera = 60;

    private void OnEnable()
    {
        //GameSettings.ChangeSens += ChangeSensMouse;
    }
    private void OnDisable()
    {
        //GameSettings.ChangeSens -= ChangeSensMouse;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (lockedCamera)
            Lookk();
    }

    private void Lookk()
    {
        transform.Rotate(0, inputController.mouse.x * MouseSens, 0);
        _xRot = Mathf.Clamp(_xRot - inputController.mouse.y * MouseSens, -reviewCamera, reviewCamera);
        headMove.transform.localRotation = Quaternion.Euler(_xRot, 0, 0);
    }


    public void UnlockCamera(bool islockedCamera)
    {
        lockedCamera = islockedCamera;
    }

    public void HidReview(int review)
    {
        reviewCamera = review;
    }

    public void ChangeSensMouse(float sens)
    {
        Debug.Log(MouseSens);
        MouseSens = sens;
    }
}
