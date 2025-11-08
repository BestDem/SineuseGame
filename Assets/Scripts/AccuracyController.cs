using UnityEngine;
using System.Collections.Generic;

public class AccuracyController : MonoBehaviour
{

    private List<Transform> cords = new List<Transform>();

    private int cur_ind = 0;
    private int taps = 0;

    private float loss = 0;

    [SerializeField] private float perfectDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private UnityEngine.UI.Text text;
    [SerializeField] private GameObject triggers;


    void Awake()
    {
        GameManager.OnMovement += UpdateAccuracy;
        foreach (Transform trans in triggers.transform)
        {
            cords.Add(trans);
        }
        cords.Sort((a, b) => a.position.x.CompareTo(b.position.x));
    }

    void Update()
    {
        float cur_x = 0;
        if (cur_ind < cords.Count)
        {
            cur_x = cords[cur_ind].position.x;
        }
        if (cur_x <= -1f)
        {
            cur_ind++;
        }
        //if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        //{
        //    //while (cords[cur_ind].position.x < 0) {
        //    //    cur_ind++;
        //    //}
        //    if (cur_ind >= cords.Count) return;
        //    if (cur_x >= 15f) return;
        //    loss += Mathf.Clamp01((Mathf.Abs(cur_x) - perfectDistance) / (maxDistance - perfectDistance));
        //    taps++;
        //    text.text = "Точность: " + getAccuracy().ToString("F2") + "%";
        //}
    }

    void UpdateAccuracy()
    {
        //while (cords[cur_ind].position.x < 0) {
        //    cur_ind++;
        //}
        float cur_x = 0;
        if (cur_ind < cords.Count)
        {
            cur_x = cords[cur_ind].position.x;
        }
        if (cur_ind >= cords.Count) return;
        if (cur_x >= 15f) return;
        loss += Mathf.Clamp01((Mathf.Abs(cur_x) - perfectDistance) / (maxDistance - perfectDistance));
        taps++;
        text.text = "Точность: " + getAccuracy().ToString("F2") + "%";
    }

    public float getAccuracy()
    {
        if (taps == 0)
        {
            return 100f;
        }
        else
        {
            return (1 - loss / taps) * 100;
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
        if (getAccuracy() >= 90 && level == 1)
            PlayerPrefs.SetInt("Skin_1", 1);

        if (getAccuracy() >= 100 && level == 1)
            PlayerPrefs.SetInt("Skin_2", 1);
    }

    private void OnDestroy()
    {
        GameManager.OnMovement -= UpdateAccuracy;
    }

}
