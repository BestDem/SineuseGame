using UnityEngine;
using System.Collections.Generic;

public class ResultTrigger : MonoBehaviour
{
    [SerializeField] private GameObject canvasResult;
    [SerializeField] private int level;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasResult.SetActive(true);
            int tries = PlayerPrefs.GetInt("Level_" + level + "_tries", 0);
            //List<float> childs = new List<float>();
            for (int i = 1; i <= 5; i++)
            {
                canvasResult.transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 1; i <= tries; i++)
            {
                Debug.Log("Level_" + level + "_accuracy_" + i);
                Debug.Log(PlayerPrefs.GetFloat("Level_" + level + "_accuracy_" + i, 0));
                canvasResult.transform.GetChild(i).gameObject.SetActive(true);
                canvasResult.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetFloat("Level_" + level + "_accuracy_" + (i - 1), 0).ToString("F2") + "%";
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasResult.SetActive(false);
        }
    }
}
