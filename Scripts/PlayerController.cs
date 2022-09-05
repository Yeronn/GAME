using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public static PlayerController Instance;
    public GameObject playerInstance;
    public Animator animator;

    [SerializeField] Image HealthbarImage;
    [SerializeField] GameObject ui;
    [SerializeField] GameObject cameraHolder;

    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed ,jumpForce, smoothTime;

    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Rigidbody rb;
    PhotonView PV;

    public GameObject bombPrefab;
    public Transform bombSpawn;

    public float cooldownTime;
    float nextBombTime;

    public float damageReceived;

    [Tooltip("The current Health of our player")]
    public float Health;
    float maxHealth;
    #region MonoBehaviourPunCallbacks
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        nextBombTime = 0;
        maxHealth = Health;
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            return;
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(ui);
        }
    }

    private void Update()
    {
        if (!PV.IsMine)
            return;
        Look();
        Move();
        AnimationMove();
        Jump();
        Bomb();
        
        if (transform.position.y < -5f)
        {
            playerInstance.GetComponent<PhotonView>().RPC("SetPlayer", RpcTarget.AllBuffered);
        }
    }

    #endregion

    #region Basic Controls
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60f, 70f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }

    void AnimationMove()
    {
       animator.SetFloat("MovX", Input.GetAxisRaw("Horizontal")); 
       animator.SetFloat("MovZ", Input.GetAxisRaw("Vertical"));
       animator.SetBool("Salta", Input.GetKeyDown(KeyCode.Space));
       animator.SetBool("Lanza", Input.GetKeyDown(KeyCode.F));
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    private void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    #endregion

    public void Bomb()
    {
        if (Time.time < nextBombTime)
        {
            //Debug.Log("Tiempo aactual: " + Time.time + " nextbomb: " + nextBombTime);
            return;
        }
            

        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0.7f;
            GameObject bomb = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "BombController"), bombSpawn.position, Quaternion.identity);
            bomb.GetComponent<PhotonView>().RPC("DestroyBomb", RpcTarget.All);
            nextBombTime = Time.time + cooldownTime;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!photonView.IsMine)
            return;

        if (collision.gameObject.tag== "damage")
        {
            Health -= damageReceived;
            HealthbarImage.fillAmount = Health / maxHealth;
        }
        if (Health <= 0)
        {
            //playerInstance.SetActive(false);
            playerInstance.GetComponent<PhotonView>().RPC("SetPlayer", RpcTarget.AllBuffered);
        }
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (!photonView.IsMine)
            return;

        if (collision.gameObject.tag == "damage")
        {
            Health -= damageReceived * 0.01f;
        }
        if (Health <= 0)
        {
            //playerInstance.SetActive(false);
            //PhotonNetwork.LeaveRoom();
            //playerInstance.GetComponent<PhotonView>().RPC("SetPlayer", RpcTarget.AllBuffered);
            PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
            Application.Quit();
        }
    }

    [PunRPC]
    void SetPlayer()
    {
        
        Debug.Log("Death Player " + PV.name);
        //playerInstance.SetActive(false);
        //this.gameObject.SetActive(false);
        
    }
}
