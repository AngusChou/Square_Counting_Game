using UnityEngine;
using UnityEngine.UI;

public class InteractionPrompt : MonoBehaviour
{
    public CanvasGroup promptGroup;

    public void Show()
    {
        promptGroup.alpha = 1;
    }

    public void Hide()
    {
        promptGroup.alpha = 0;
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
