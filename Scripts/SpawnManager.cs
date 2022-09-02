using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    public Transform[] spawnPoints;

    void Start()
    {
        Instance = this;
    }
}
