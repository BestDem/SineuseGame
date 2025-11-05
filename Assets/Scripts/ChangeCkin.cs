using UnityEngine;
using UnityEngine.UI;

public class ChangeCkin : MonoBehaviour
{
    [SerializeField] private GameObject[] needMenu;  //нумерация со 2 скина - id = 0
    [SerializeField] private Button[] buttonChangeSkin;
    private int lenthSkin;

    private void Start()
    {
        buttonChangeSkin[PlayerPrefs.GetInt("Skin", 0)].interactable = false;
        lenthSkin = needMenu.Length;
        if (PlayerPrefs.GetInt("Skin_1", 0) == 1)    //проходится по скинам и открывает те, которые получили
            TrurnOnSkin(0);

        if (PlayerPrefs.GetInt("Skin_2", 0) == 1)
            TrurnOnSkin(1);
        
    }

    private void TrurnOnSkin(int idNeedSkin)  
    {
        needMenu[idNeedSkin].SetActive(false);
    }

    public void ChangeSkinButton(int idSkin)
    {
        foreach (var button in buttonChangeSkin)
        {
            button.interactable = true;
        }
        SkinController.singletonSkin.RespawnPlayerSkin(idSkin);

        
        buttonChangeSkin[idSkin].interactable = false;
        
        PlayerPrefs.SetInt("Skin", idSkin);
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
