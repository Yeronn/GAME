using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoxController : MonoBehaviour
{
    PhotonView PV;
    public static BoxController Instance;
    public GameObject boxInstance;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!PV.IsMine || collision.gameObject.tag != "damage")
            return;
        this.GetComponent<PhotonView>().RPC("DestroyBox", RpcTarget.AllBuffered);
        /*if (!PhotonNetwork.IsMasterClient)
            return;
        PhotonNetwork.Destroy(boxInstance);*/
    }

    [PunRPC]
    void DestroyBox()
    {
        Destroy(boxInstance);
    }
}
