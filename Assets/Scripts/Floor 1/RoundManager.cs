using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public CubeSpawner spawner;
    public int currentRound = 1;
    public int maxRound = 5;

    private bool roundActive = false;

    public void StartRound()
    {
        spawner.SpawnForRound(currentRound);
        roundActive = true;
        spawner.SpawnForRound(currentRound);
    }

    public void SubmitAnswer(int answer)
    {
        int correct = spawner.GetCorrectCount();

        if (answer == correct)
        {
            currentRound++;
            if (currentRound > maxRound)
            {
                RoomComplete();
            }
            else
            {
                StartRound();
            }
        } else
        {
            ResetRoom();
        }
    }

    void ResetRoom()
    {
        currentRound = 1;
        StartRound();
    }

    void RoomComplete()
    {
        roundActive = false;
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
