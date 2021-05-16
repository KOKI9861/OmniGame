using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLastTree : MonoBehaviour
{
    GameObject GameManager;
    GameObject tree1;
    GameObject tree2;
    GameObject tree3;
    GameObject tree4;
    GameObject tree_ins;

    int shot_count;
    bool max_flg;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        shot_count = 0;
        max_flg = false;

        tree1 = (GameObject)Resources.Load("Prefab/Tree Type3 01");
        tree2 = (GameObject)Resources.Load("Prefab/Tree Type3 02");
        tree3 = (GameObject)Resources.Load("Prefab/Tree Type3 03");
        tree4 = (GameObject)Resources.Load("Prefab/Tree Type0 04");

        tree_ins = Instantiate(tree1, this.transform.position, Quaternion.identity);
        tree_ins.transform.parent = transform;
        tree_ins.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Bullet" && !max_flg){
            tree_ins.transform.localScale += new Vector3(0.05f, 0.05f, 0.05f);
            shot_count += 1;
            GameManager.GetComponent<Game_Manager>().getScore(10);
            changeTree();
        }
    }

    void changeTree(){
        if(shot_count > 60 && tree_ins.gameObject.name==(tree3.gameObject.name+"(Clone)")){
            Destroy(tree_ins);
            tree_ins = Instantiate(tree4, this.transform.position, Quaternion.identity);
            tree_ins.transform.parent = transform;
            tree_ins.transform.localScale = new Vector3(3f, 4f, 3f);
            max_flg = true;
            Invoke("clear", 3.0f);
        }
        else if(shot_count > 30 && tree_ins.gameObject.name==(tree2.gameObject.name+"(Clone)")){
            Destroy(tree_ins);
            tree_ins = Instantiate(tree3, this.transform.position, Quaternion.identity);
            tree_ins.transform.parent = transform;
            tree_ins.transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if(shot_count > 20 && tree_ins.gameObject.name==(tree1.gameObject.name+"(Clone)")){
            Destroy(tree_ins);
            tree_ins = Instantiate(tree2, this.transform.position, Quaternion.identity);
            tree_ins.transform.parent = transform;
            tree_ins.transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    void clear(){
        GameManager.GetComponent<Game_Manager>().clearGame();
    }
}
