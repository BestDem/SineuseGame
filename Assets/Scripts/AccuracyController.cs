using UnityEngine;
using System.Collections.Generic;

public class AccuracyController : MonoBehaviour
{

    private List<Transform> cords = new List<Transform>();

    private int cur_ind = 0;

    private float loss = 0;

    [SerializeField] private float perfectDistance = 0.4f;
    [SerializeField] private float maxDistance = 1f;


    void Awake()
    {
        foreach (Transform trans in transform)
        {
            cords.Add(trans);
        }
        cords.Sort((a, b) => a.position.x.CompareTo(b.position.x));
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            //while (cords[cur_ind].position.x < 0) {
            //    cur_ind++;
            //}
            if (cur_ind >= cords.Count) return;
            float cur_x = cords[cur_ind].position.x;
            loss += Mathf.Clamp01((Mathf.Abs(cur_x) - perfectDistance) / (maxDistance - perfectDistance));
            cur_ind++;

        }
    }

    float getAccuracy()
    {
        if (cur_ind == 0)
        {
            return 100f;
        }
        else
        {
            return (1 - loss / cur_ind) * 100;
        }
    }
}
