using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject GameManager;
    GameObject panel;
    public float acc = 0.3f;

    GameObject Gun;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        panel = GameObject.Find("Panel");

        Gun = gameObject.transform.Find("Main Camera/Gun").gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        
        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.forward * acc;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= transform.forward * acc;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += transform.right * acc;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position -= transform.right * acc;
        }

    }


    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "MovingBlock"){
            collision.gameObject.GetComponent<Move_ground>().moveStart();
        }else if(collision.gameObject.tag == "SwitchPlane"){
            GameManager.GetComponent<Game_Manager>().putMoveBlock();
        }
    }
    

    
}
