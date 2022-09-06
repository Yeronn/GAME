
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    public Transform[] spawnPoints;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        if (!PV.IsMine)
            return;
        CreateController();
    }

    void CreateController()
    {
        Debug.Log("Instantiated Player Controller");
        //Instantiate our player controller
        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), Vector3.zero, Quaternion.identity);

        //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"), new Vector3(2,2,2), Quaternion.identity);
        if (PV.ViewID == 1001)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPoints[0].position, spawnPoints[0].rotation);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), spawnPoints[0].position, spawnPoints[0].rotation);
        }
        else if (PV.ViewID  == 2001)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPoints[1].position, spawnPoints[1].rotation);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), spawnPoints[1].position, spawnPoints[1].rotation);
        }
        else if (PV.ViewID == 3001)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPoints[2].position, spawnPoints[2].rotation);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), spawnPoints[2].position, spawnPoints[2].rotation);
        }
        else if (PV.ViewID == 4001)
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnPoints[3].position, spawnPoints[3].rotation);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), spawnPoints[3].position, spawnPoints[3].rotation);
        }
        else
        {
            //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), new Vector3(12,-1,0), Quaternion.identity);
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerModel"), new Vector3(12,-1,0), Quaternion.identity);
            Debug.Log("ViewID: " + PV.ViewID);
        }
    }


}
