using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteor : MonoBehaviour
{
    GameObject GameManager;

    GameObject MeteorCrash;
    Vector3 start_pos;
    Vector3 dir;
    Quaternion rotate;
    public float acc = 0.01f;
    public float maxspeed = 0.3f;
    // float time = 0f;
    float interval = 15f;

    AudioSource fall_sound;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");

        start_pos = new Vector3(Random.Range(-80, 80), 150, Random.Range(-120, 30));
        transform.position = start_pos;
        if(Random.value < 0.8){
            dir = new Vector3(Random.Range(-1f, 1f), -Random.value, Random.Range(-1f, 1f));
        }else{
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            dir = (player.transform.position - transform.position);
        }
        dir = dir/dir.magnitude;

        // 回転
        rotate = Quaternion.Euler(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        // time = 0f;

        MeteorCrash = (GameObject)Resources.Load("Prefab/MeteorCrash");

        fall_sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y < -50){
            Destroy(this.gameObject);
        }

        // time += Time.deltaTime;
 
    }

    void Move()
    {
        float speed = maxspeed - acc * Mathf.Pow(transform.position.y/100f, 2f);
        if(speed <= acc){
            speed = acc;
        }
        transform.position += dir * speed;

        // 回転
        transform.rotation *= rotate;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject obj = Instantiate(MeteorCrash, this.transform.position, Quaternion.identity);
        obj.transform.parent = transform.parent;
        
        // fall_sound.PlayOneShot(fall_sound.clip);
        Destroy(this.gameObject);
        // Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag == "Bullet"){
            GameManager.GetComponent<Game_Manager>().getScore(10);
        }else if(collision.gameObject.tag == "Player"){
            GameManager.GetComponent<Game_Manager>().downHP(10);
            GameManager.GetComponent<Game_Manager>().panelRed();

        }

    }

    

    
}
