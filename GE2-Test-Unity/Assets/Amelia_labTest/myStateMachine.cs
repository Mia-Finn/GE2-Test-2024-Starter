using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myStateMachine : MonoBehaviour
{
    //A state machine script for the snake!!!!!

    //bools
    public bool canIdle;
    public bool canChase;
    public bool canFlee;

    //other stuff
    public GameObject player;
    public float speed = 1;
    public Rigidbody rb;

    //state machine
    public enum State { idle, flee, chase }
    public State currentState;

    public void Start()
    {
        currentState = State.idle;
    }

    // Update is called once per frame
    void Update()
    {
        //state machine
        switch (currentState)
        {
            case State.idle:
                if (canIdle == true)
                {
                    // idle();
                    Debug.Log("IDLE!!!!!");
                }
                else if (canChase == true)
                {
                    currentState = State.chase;
                }
                else if (canFlee == true)
                {
                    currentState = State.flee;
                }
                break;

            case State.flee:
                if (canFlee == true)
                {
                    flee();
                }
                else if (canChase == true)
                {
                    currentState = State.chase;
                }
                else if (canIdle == true)
                {
                    currentState = State.idle;
                }
                break;

            case State.chase:
                if (canChase == true)
                {
                    chase();
                }
                else if (canIdle == true)
                {
                    currentState = State.idle;
                }
                else if (canFlee == true)
                {
                    currentState = State.flee;
                }
                break;
        }

        boolControl();
    }

    void idle()
    {
        if (canIdle == true)
        {
            // gameObject.transform.position = new Vector3(0, 0, 0);
            transform.position = this.transform.position;
            Debug.Log("IDLE!!!!!");
        }
    }

    void chase()
    {
        if (canChase == true)
        {
            Vector3 dest = player.transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            transform.position = newPos;
            Debug.Log("Chasing!!!!!");

            //Face movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos.normalized), 0.2f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos), 0.15F);
            /*
            Vector3 lookDirection = newPos + gameObject.transform.position;
            gameObject.transform.LookAt(lookDirection);
            */
            // transform.rotation = Quaternion.LookRotation(rb.velocity); 
        }

        //  Debug.Log("Chase running!");
    }

    void flee()
    {
        if (canFlee == true)
        {
            Vector3 dest = gameObject.transform.position - player.transform.position;
            Vector3 newPos = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            transform.position = newPos;
            Debug.Log("Fleeing!!!!");

            //turn moving direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newPos.normalized), 0.2f);
            /*
            Vector3 lookDirection = newPos + gameObject.transform.position;
            gameObject.transform.LookAt(lookDirection);
            */
        }
    }

    void boolControl()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            canIdle = true;
            canFlee = false;
            canChase = false;
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            canIdle = false;
            canFlee = false;
            canChase = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            canIdle = false;
            canFlee = true;
            canChase = false;
        }
    }
}
