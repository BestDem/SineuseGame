using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screen_fader : MonoBehaviour
{
    private float numIter = 100;
    [SerializeField] private float fadeTime = 0.5f;
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
        while (colorIm.a > 0f)
        {
            colorIm.a -= 1 / numIter;
            image.color = colorIm;
            yield return new WaitForSeconds(fadeTime / numIter);
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
            colorIm.a += 1 / numIter;
            image.color = colorIm;
            yield return new WaitForSeconds(fadeTime / numIter);
        }
        
        colorIm.a = 1f;
        image.color = colorIm;
    }
}
