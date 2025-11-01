using NUnit.Framework;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public static SkinController singletonSkin { get; private set; }
    [SerializeField] private GameObject[] prefSkin;
    [SerializeField] private Transform spawnPointPlayer;
    private int currentSkin;

    private void Awake()
    {
        //через ивент сделать открытие скинов тут
        singletonSkin = this;

        currentSkin = PlayerPrefs.GetInt("Skin", 0);

        Instantiate(prefSkin[currentSkin], spawnPointPlayer.transform.position, Quaternion.identity);
    }
    
    public void OpenSkin(string nameSkin)
    {
        PlayerPrefs.SetInt(nameSkin, 1);
    }

    public Transform TransSpawn()
    {
        return spawnPointPlayer;
    }
}
