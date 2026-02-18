using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public Cube_Spawner spawner;
    public TMP_InputField guessInput;

    [Header("Level Settings")]
    public int level = 1;
    public float observationTime = 3f;

    public int currentCubeCount;
    public bool waitingForGuess = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LevelRoutine());
    }

    IEnumerator LevelRoutine()
    {
        currentCubeCount = GenerateCubeCount(level);
        spawner.SpawnCubes(currentCubeCount);
        yield return new WaitForSeconds(observationTime);
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cube.SetActive(false);
        }
        waitingForGuess = true;
    }

    int GenerateCubeCount(int level)
    {
        int baseAmount = 3 + Mathf.FloorToInt(Mathf.Pow(level, 0.7f));
        int randomness = Random.Range(0, Mathf.FloorToInt(Mathf.Pow(level, 0.5f)) + 1);
        return baseAmount + randomness;
    }

    public void SubmitGuess()
    {
        if (!waitingForGuess)
        {
            return;
        }

        if (int.TryParse(guessInput.text, out int guess))
        {
            if (guess == currentCubeCount)
            {
                level++;
                Debug.Log("Correct! Moving to level " + level);
                RestartLevel();
            } else
            {
                Debug.Log("Wrong! You died. Back to level 0...");
                level = 1;
                RestartLevel();
            }
        }
    }

    public void RestartLevel()
    {
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            Destroy(cube);
        }

        guessInput.text = "";
        StartCoroutine(LevelRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForGuess && Input.GetKeyDown(KeyCode.Return))
        {
            SubmitGuess();
        }
    }
}
