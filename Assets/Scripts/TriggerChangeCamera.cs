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
            Debug.Log("Вошел");
            if (upCamera)
            {
                timelineToSide.Play();
                upCamera = false;
            }
            else
            {
                Debug.Log("Обратно ");
                timelineToUp.Play();
                upCamera = true;
            }
        }
    }
}
