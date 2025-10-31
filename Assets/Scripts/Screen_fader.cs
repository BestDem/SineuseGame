using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screen_fader : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 1f;
    [SerializeField] private Image image;
    private Color colorIm;

    private void Start()
    {
        //image = GetComponent<Image>();
        colorIm = image.color;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("Осветление");
        while (colorIm.a > 0f)
        {
            colorIm.a -= fadeSpeed * Time.deltaTime;
            image.color = colorIm;
            yield return null;
        }
        
        colorIm.a = 0f;
        image.color = colorIm;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        while (colorIm.a < 1f)
        {
            colorIm.a += fadeSpeed * Time.deltaTime;
            image.color = colorIm;
            yield return null;
        }
        
        colorIm.a = 1f;
        image.color = colorIm;
    }
}
