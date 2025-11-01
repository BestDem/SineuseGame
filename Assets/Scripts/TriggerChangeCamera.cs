using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerChangeCamera : MonoBehaviour
{
    [SerializeField] private PlayableDirector timelineToSide;
    [SerializeField] private PlayableDirector timelineToUp;
    private bool upCamera = true;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (upCamera)
            {
                Debug.Log("Камера в бок");
                timelineToSide.Play();
                upCamera = false;
            }
            else
            {
                Debug.Log("Вверх");
                timelineToUp.Play();
                upCamera = true;
            }
        }
    }
}
