using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_ground : MonoBehaviour
{
    public Vector3 start_pos = new Vector3(0f, -0.2f, -18f);
    public Vector3 goal_pos = new Vector3(0f, -0.2f, -53f);
    public float acc = 0.001f;
    Vector3 dir;
    bool move_flg = false;
    bool forward = true;
    int sum_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = start_pos;
        dir = acc * (goal_pos - start_pos);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move_flg){
            Move();
        }
    }

    void Move()
    {
        if(forward){
            transform.position += dir;
        }else{
            transform.position -= dir;
        }

        sum_count++;
        if(sum_count > (int)1/acc){
            forward = !forward;
            sum_count = 0;
            move_flg = false;
            Invoke("move_flg_true", 3.0f);
        }
        
    }

    void move_flg_true()
    {
        move_flg = true;
    }

    public void moveStart(){
        if(move_flg == false){
            Invoke("move_flg_true", 1.0f);
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // Debug.Log("move");
    //     if(collision.gameObject.tag == "Player"){
    //         Invoke("move_flg_true", 1.0f);
    //     }
    // }
}
