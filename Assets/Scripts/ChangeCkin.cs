using UnityEngine;
using UnityEngine.UI;

public class ChangeCkin : MonoBehaviour
{
    [SerializeField] private GameObject[] needMenu;
    [SerializeField] private Button[] buttonChangeSkin;
    private int lenthSkin;

    private void Start()
    {
        lenthSkin = needMenu.Length;
        if (PlayerPrefs.GetInt("Skin_1", 0) == 1)
            TrurnOnSkin(0);

        if (PlayerPrefs.GetInt("Skin_2", 0) == 1)
            TrurnOnSkin(1);
        
    }

    private void TrurnOnSkin(int idNeedSkin)
    {
        for (int i = 0; i < lenthSkin; i++)
        {
            if (i == idNeedSkin)
                needMenu[i].SetActive(false);
        }
    }

    public void ChangeSkinButton(int idSkin)
    {
        foreach (var button in buttonChangeSkin)
        {
            button.interactable = true;
        }

        buttonChangeSkin[idSkin].interactable = false;
        
        PlayerPrefs.SetInt("Skin", idSkin);
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
