using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ActionObject
{
    GameObject Bullet;
    bool shotflag = true;

    AudioSource shot_sound;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("Prefab/Bullet");

        shot_sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Shot();
        }
    }

    void Shot(){
        GameObject bullet = Instantiate(Bullet);
        bullet.transform.SetParent(transform, false);

        shot_sound.PlayOneShot(shot_sound.clip);
    }


    protected override void TriggerTouchDown(float x, params object[] args){
        if(x>0.5){
            if(shotflag){
            shotflag = false;
            Shot();
            }
        }else{
            shotflag = true;
        }
        
        
    }
}
