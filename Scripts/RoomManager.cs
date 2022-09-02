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

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(6, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(5, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, -6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(4, -1, 6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(3, -1, 6), Quaternion.identity);


        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(2, -1, -4), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(1, -1, -4), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(0, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-1, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-2, -1, -6), Quaternion.identity);
        
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-3, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-3, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-3, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-3, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-3, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-4, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-5, -1, -6), Quaternion.identity);

        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 6), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, 0), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -1), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -2), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -3), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -4), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -5), Quaternion.identity);
        PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "BoxController"), new Vector3(-6, -1, -6), Quaternion.identity);


    }
}
