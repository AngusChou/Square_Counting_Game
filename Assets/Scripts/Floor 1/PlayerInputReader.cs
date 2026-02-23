using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{

    public int answer = 0;

    public void Increase()
    {
        answer++;
    }

    public void Decrease()
    {
        if (answer > 0)
        {
            answer--;
        }
    }

    public int GetAnswer()
    {
        return answer;
    }

    public void ResetAnswer()
    {
        answer = 0;
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
