using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    bool rightTurn;
    bool leftTurn;
    public float divideSpeed;
    public float rotationSpeed;
    public bool canMove;
    private MeshRenderer meshRenderer;
    private Collider collideR;
    public static PlayerMove instance;
    public static List<PlayerMove> all;
   
    private void Awake()
    {
        instance = this;
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        collideR = GetComponentInChildren<Collider>();
    }
    private void OnEnable()
    {
        if (all == null) all = new List<PlayerMove>();
        all.Add(this);
    }
    private void OnDisable()
    {
        all.Remove(this);
    }
    void Update()
    {
        if (canMove)
        {
            transform.position += transform.forward / divideSpeed;

            //// To test on PC
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
            }
            ////
            if (rightTurn)
            {
                transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
            }
            if (leftTurn)
            {
                transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
            }
        }
    }
    public void SetComponents(bool enable)  //to prepare car to game(to make it visible)
    {
        meshRenderer.enabled = enable;
        collideR.enabled = enable;
    }
    public void CanWeMove(bool move)
    {
        canMove=move;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.ReTry();
        }
    }
    public void TurnControl(bool left,bool right)
    {
        rightTurn = right;
        leftTurn = left;
    }
}
