using UnityEngine;

public class SubmitButton : Interactable
{

    public RoundManager roundManager;
    public PlayerInputReader inputReader;

    public void Submit()
    {
        int answer = inputReader.GetAnswer();
        roundManager.SubmitAnswer(answer);
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
