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
        int baseAmount = Random.Range(level, level + 3);
        int randomness = Random.Range(baseAmount, baseAmount + level);
        return randomness;
    }

    public void SubmitGuess()
    {
        if (!waitingForGuess)
        {
            return;
        }
        // int answer = int.Parse(guessInput.text);
        if (!int.TryParse(guessInput.text, out int answer))
        {
            return;
        }
        if (answer == currentCubeCount)
        {
            level++;
            Debug.Log("Correct!");
            waitingForGuess = false;
            RestartLevel();
        }
        else
        {
            level = 1;
            Debug.Log("Wrong!");
            waitingForGuess = false;
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        foreach (var cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            Destroy(cube);
        }

        spawner.ResetCubes();
        guessInput.text = "";
        StartCoroutine(LevelRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        guessInput.gameObject.SetActive(waitingForGuess);
    }
}
