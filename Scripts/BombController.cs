using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class BombController : MonoBehaviourPunCallbacks
{
    public float destroyTime = 2f;

    PhotonView PV;

    public GameObject damage;
    public float cubeSize, cubeDestroyTime;
    public int cubesRow;
    public float explosionForce;
    
    float cubesPivotDistance;
    Vector3 cubesPivot;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        damage.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
    }

    private void Start()
    {
        if (!PV.IsMine)
            return;
        
        //calculate pivot distace
        cubesPivotDistance = cubeSize * cubesRow / 2;
        //use this vaalue to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    [PunRPC]
    IEnumerator DestroyBomb()
    {
        if (!PV.IsMine)
            yield break;

        yield return new WaitForSeconds(destroyTime);
        this.GetComponent<PhotonView>().RPC("Destroy", RpcTarget.All);
    }


    [PunRPC]
    public void Destroy()
    {
        Destroy(this.gameObject);
        Explode();
    }

    public void Explode()
    {
        //loop 3 times to create cubesRow in x,y,z
        for (int x = 0; x < cubesRow; x++)
        {
            for (int y = 0; y < cubesRow; y++)
            {
                for (int z = 0; z < cubesRow; z++)
                {
                    Vector3 spawn = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
                    //PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Damage"), spawn, Quaternion.identity);
                    GameObject  instance = Instantiate(damage, spawn, Quaternion.identity);
                    Destroy(instance, cubeDestroyTime);
                }
            }
        }
        //get explosion position
        Vector3 explosionPos = transform.position;
        Vector3 damageSize = damage.GetComponent<Transform>().localScale;
        
        //Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        Collider[] colliders = Physics.OverlapBox(explosionPos, damageSize * cubesRow / 2);
        

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            Vector3 tr = hit.GetComponent<Transform>().position;
            if (rb != null)
            {
                if (tr.x - explosionPos.x > 0 && tr.z - explosionPos.z > 0)
                {
                    rb.AddRelativeForce(transform.forward * explosionForce);
                }
                else if (tr.x - explosionPos.x < 0 && tr.z - explosionPos.z > 0)
                {
                    rb.AddRelativeForce(- transform.right * explosionForce);
                }
                else if (tr.x - explosionPos.x < 0 && tr.z - explosionPos.z < 0)
                {
                    rb.AddRelativeForce(-transform.forward * explosionForce);
                }
                else if (tr.x - explosionPos.x > 0 && tr.z - explosionPos.z < 0)
                {
                    rb.AddRelativeForce(transform.right * explosionForce);
                }
            }
        }
    }
}
