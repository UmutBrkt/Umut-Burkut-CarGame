using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    bool rightTurn;
    bool leftTurn;
    public float divideSpeed;
    public float rotationspeed;
    public bool canMove;
    public static PlayerMove instance;
    public static List<PlayerMove> all;
    private void Awake()
    {
        instance = this;
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
                transform.Rotate(Vector3.up * (rotationspeed * Time.deltaTime));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.down * (rotationspeed * Time.deltaTime));
            }
            ////
            if (rightTurn)
            {
                transform.Rotate(Vector3.up * (rotationspeed * Time.deltaTime));
            }
            if (leftTurn)
            {
                transform.Rotate(Vector3.down * (rotationspeed * Time.deltaTime));
            }
        }
    }
    public void SetComponents(bool enable)  //to prepare car to game(to make it visible)
    {
        GetComponentInChildren<MeshRenderer>().enabled = enable;
        GetComponentInChildren<Collider>().enabled = enable;
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
