using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Screen_fader : MonoBehaviour
{
    private float numIter = 10;
    [SerializeField] private float fadeTime = 0.5f;
    [SerializeField] private Image imageDark;
    [SerializeField] private GameObject imageStartDelay;
    private Color colorIm;

    private void Start()
    {
        //image = GetComponent<Image>();
        colorIm = imageDark.color;

        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (colorIm.a > 0f)
        {
            colorIm.a -= 1f/ numIter;
            imageDark.color = colorIm;
            yield return new WaitForSecondsRealtime(fadeTime / numIter);
        }
        
        
        colorIm.a = 0f;
        imageDark.color = colorIm;

        StartCoroutine(StartDelay());
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        while (colorIm.a < 1f)
        {
            colorIm.a += 1f / numIter;
            imageDark.color = colorIm;
            yield return new WaitForSecondsRealtime(fadeTime / numIter);
        }

        colorIm.a = 1f;
        imageDark.color = colorIm;
    }
    
    private IEnumerator StartDelay()
    {
        imageStartDelay.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        imageStartDelay.SetActive(false);
    }
}
