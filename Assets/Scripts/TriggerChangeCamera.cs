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
        Debug.Log("Коснулся");
        if (collider.gameObject.tag == "Player")
        {
            if (upCamera)
            {
                timelineToSide.Play();
                upCamera = false;
            }
            else
            {
                timelineToUp.Play();
                upCamera = true;
            }
        }
    }
}
