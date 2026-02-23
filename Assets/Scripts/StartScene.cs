using UnityEngine;

public class StartScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FadeController.Instance.FadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
