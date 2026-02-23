using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Cube_Spawner : MonoBehaviour
{
    [Header("Prefabs / Target")]
    public GameObject cubePrefab;
    public Transform platform;

    [Header("Grid")]
    public int gridSize = 8;
    public bool platformPivotIsCenter = true;

    public int[,] stackHeights;

    private float cellSize;
    private float cubeSize;
    private float platformThickness;

    public void Awake()
    {
        cubeSize = 0.125f;
        platformThickness = platform.localScale.y; 

        float platformWidth = platform.localScale.x;
        float platformDepth = platform.localScale.z;

        cellSize = platformWidth / gridSize;
        stackHeights = new int[gridSize, gridSize];
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public List<GameObject> SpawnCubes(int count)
    {
        List<GameObject> spawnedCubes = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            int x = UnityEngine.Random.Range(0, gridSize);
            int z = UnityEngine.Random.Range(0, gridSize);
            int height = stackHeights[x, z];
            stackHeights[x, z]++;
            Vector3 position = ComputeCubePosition(x, z, height);
            GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
            spawnedCubes.Add(cube);
        }

        return spawnedCubes;
    }

    public void ResetCubes()
    {
        stackHeights = new int[gridSize, gridSize];
    }

    private Vector3 ComputeCubePosition(int gx, int gz, int height)
    {
        Vector3 basePosition = platform.position;
        float half = platformPivotIsCenter ? 0.5f : 0f;

        float x = basePosition.x + (gx + 0.5f - half * gridSize) * cellSize;
        float z = basePosition.z + (gz + 0.5f - half * gridSize) * cellSize;
        float y = basePosition.y + platformThickness / 2f + cubeSize / 2f + height * cubeSize;
        return new Vector3(x, y, z);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
