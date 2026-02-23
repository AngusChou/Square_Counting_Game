using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance;

    public Image fadeImage;
    public float fadeSpeed = 1f;

    private void Awake()
    {
        Instance = this;
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1));
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(0));
    }

    IEnumerator Fade(float targetAlpha)
    {
        Color c = fadeImage.color;
        while (!Mathf.Approximately(c.a, targetAlpha))
        {
            c.a = Mathf.MoveTowards(c.a, targetAlpha, fadeSpeed * Time.deltaTime);
            fadeImage.color = c;
            yield return null;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
