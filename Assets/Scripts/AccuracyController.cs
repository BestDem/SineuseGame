using UnityEngine;
using System.Collections.Generic;

public class AccuracyController : MonoBehaviour
{

    private List<Transform> cords = new List<Transform>();

    private int cur_ind = 0;

    private float loss = 0;

    [SerializeField] private float perfectDistance = 0.1f;
    [SerializeField] private float maxDistance = 1f;
    [SerializeField] private UnityEngine.UI.Text text;


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
        float cur_x = cords[cur_ind].position.x;
        if (cur_x <= -4f)
        {
            cur_ind++;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            //while (cords[cur_ind].position.x < 0) {
            //    cur_ind++;
            //}
            if (cur_ind >= cords.Count) return;
            if (cur_x >= 4f) return;
            loss += Mathf.Clamp01((Mathf.Abs(cur_x) - perfectDistance) / (maxDistance - perfectDistance));
            cur_ind++;
            text.text = "Точность: " + getAccuracy().ToString("F2") + "%";
        }
    }

    public float getAccuracy()
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

    public void SaveAccuracy(int level)
    {
        List<float> accuracies = new List<float>();
        int tries = PlayerPrefs.GetInt("Level_" + level + "_tries", 0);
        for (int i = 0; i < tries; i++)
        {
            accuracies.Add(PlayerPrefs.GetFloat("Level_" + level + "_accuracy_" + i, 0f));
        }
        accuracies.Add(getAccuracy());
        accuracies.Sort();
        accuracies.Reverse();

        UnblockSkin(level);

        if (accuracies.Count > 5)
        {
            accuracies.RemoveAt(5);
        }
        else
        {
            tries += 1;
            PlayerPrefs.SetInt("Level_" + level + "_tries", tries);
        }
        for (int i = 0; i < accuracies.Count; i++)
        {
            Debug.Log(accuracies[i]);
            PlayerPrefs.SetFloat("Level_" + level + "_accuracy_" + i, accuracies[i]);
        }
    }

    public List<float> GetAccuracies(int level)
    {
        List<float> accuracies = new List<float>();
        int tries = PlayerPrefs.GetInt("Level_" + level + "_tries", 0);
        for (int i = 0; i < tries; i++)
        {
            accuracies.Add(PlayerPrefs.GetFloat("Level_" + level + "_accuracy_" + i, 0f));
        }
        return accuracies;
    }

    private void UnblockSkin(int level)
    {
        if (getAccuracy() > 95 && level == 1)
            PlayerPrefs.SetInt("Skin_1", 1);

        if (getAccuracy() > 95 && level == 2)
            PlayerPrefs.SetInt("Skin_2", 1);
    }

}
