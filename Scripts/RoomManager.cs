using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    private void Awake()
    {
        if (Instance) // check if another roomManager exists
        {
            Destroy(gameObject); //there can only be one
            return;
        }
        DontDestroyOnLoad(gameObject); //I am only one
        Instance = this;
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 1) // We're in the game scene
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
            MapCreation();
            
        }
    }

    void MapCreation()
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        int contz = 1;
        for (int z = 10; z >= -10;  z -= 2)
        {
            int contx = 0;
            for (int x = -12; x <= 12; x += 2)
            {
                contx += 1;
                if (contx == 2 && contz % 2 == 0)
                {
                    contx = 0;
                    continue;
                }

                if ((x == -12 && z == 10) || (x == -10 && z == 10) || (x == -12 && z == 8) || (x == 10 && z == 6) ||
                    (x == 12 && z == 6) || (x == 12 && z == 4) || (x == 2 && z == -6) || (x == 4 && z == -6) ||
                    (x == 4 && z == -8) || (x == -12 && z == -8) || (x == -12 && z == -10) || (x == -10 && z == -10))
                {
                    continue;
                }
                PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(x, -1, z), Quaternion.identity);
            }
            contz++;
        }
    }
}
