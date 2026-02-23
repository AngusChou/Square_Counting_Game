using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Highlightable highlightable;
    public InteractionPrompt prompt;

    public virtual void Interact()
    {
        // Override in derived classes for specific interaction behavior
    }

    public void OnLookAt()
    {
        if (highlightable != null)
        {
            highlightable.Highlight();
        }
        if (prompt != null)
        {
            prompt.Show();
        }
    }

    public void OnLookAway()
    {
        if (highlightable != null)
        {
            highlightable.Unhighlight();
        }

        if (prompt != null)
        {
            prompt.Hide();
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
