using UnityEngine;
using System.Collections.Generic;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform spawnArea;

    private List<GameObject> spawnedCubes = new List<GameObject>();
    private int correctCount = 0;

    public void SpawnForRound(int round)
    {
        ClearOldCubes();
        switch (round)
        {
            case 1:
                correctCount = SpawnSimplePattern();
                break;
            //case 2:
            //    correctCount = SpawnMediumPattern();
            //    break;
            //case 3:
            //    correctCount = SpawnMovingPattern();
            //    break;
            //case 4:
            //    correctCount = SpawnDarkRoomPattern();
            //    break;
            //case 5:
            //    correctCount = SpawnRotatingPlatformPattern();
            //   break;
        }
    }

    public int SpawnSimplePattern()
    {
        int cubeCount = Random.Range(5, 10);
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 position = GetRandomPositionInArea();
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
            spawnedCubes.Add(cube);
        }
        return cubeCount;
    }

    Vector3 GetRandomPositionInArea()
    {
        Vector3 center = spawnArea.position;
        Vector3 size = spawnArea.localScale;

        float x = center.x + Random.Range(-size.x / 2, size.x / 2);
        float y = center.y;
        float z = center.z + Random.Range(-size.z / 2, size.z / 2);

        return new Vector3(x, y, z);
    }
    public int GetCorrectCount()
    {
        return correctCount;
    }

    void ClearOldCubes()
    {
        foreach(GameObject cube in spawnedCubes)
        {
            Destroy(cube);
        }

        spawnedCubes.Clear();
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
