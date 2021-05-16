using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class omniPlayer : MonoBehaviour
{
    GameObject GameManager;
    GameObject panel;

    
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        panel = GameObject.Find("Panel");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log(collision.gameObject.name);
    // }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        // Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "MovingBlock"){
            collision.gameObject.GetComponent<Move_ground>().moveStart();
        }else if(collision.gameObject.tag == "SwitchPlane"){
            GameManager.GetComponent<Game_Manager>().putMoveBlock();
        }

    }


}
