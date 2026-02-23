using UnityEngine;

public class StartPanel : Interactable
{

    public RoundManager roundManager;

    public override void Interact()
    {
        roundManager.StartRound();
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
