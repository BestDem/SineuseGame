using NUnit.Framework;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public static SkinController singletonSkin { get; private set; }
    [SerializeField] private GameObject[] prefSkin;
    [SerializeField] private Transform spawnPointPlayer;
    private int currentSkin;
    private GameObject currentPlSkin;

    private void Awake()
    {
        //через ивент сделать открытие скинов тут
        singletonSkin = this;

        currentSkin = PlayerPrefs.GetInt("Skin", 0);
        currentPlSkin = Instantiate(prefSkin[currentSkin], spawnPointPlayer.transform.position, Quaternion.Euler(0,90,0));
    }
    
    public void OpenSkin(string nameSkin)
    {
        PlayerPrefs.SetInt(nameSkin, 1);
    }

    public Transform TransSpawn()
    {
        return spawnPointPlayer;
    }

    public void RespawnPlayerSkin(int id)
    {
        Destroy(currentPlSkin);

        currentPlSkin = Instantiate(prefSkin[id], spawnPointPlayer.transform.position, Quaternion.Euler(0, 90, 0));
    }
    
}
