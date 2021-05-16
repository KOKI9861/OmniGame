using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float acc = 0.3f;
    float time = 5f;
    Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        forward = transform.parent.transform.forward;
        transform.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        transform.position += forward * acc;
        Invoke("Destroythis", time);
    }

    void Destroythis(){
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision){
        Destroythis();
    }
}
