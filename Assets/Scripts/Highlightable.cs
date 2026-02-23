using UnityEngine;

public class Highlightable : MonoBehaviour
{

    public Renderer targetRenderer;
    public Color highlightColor = Color.yellow;
    private Color originalColor;
    public bool highlighted { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalColor = targetRenderer.material.color;
    }

    public void Highlight()
    {
        highlighted = true;
        targetRenderer.material.color = highlightColor;
    }

    public void Unhighlight()
    {
        highlighted = false;
        targetRenderer.material.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
