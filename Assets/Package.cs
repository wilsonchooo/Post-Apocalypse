using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public static bool retrieved = true;
    public SpriteRenderer sprite;
    public Collider2D boxcollid;
    public Rigidbody2D rigid;
    public int boxspeedx;
    public int boxspeedy;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxcollid = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (retrieved == true)
        {
            transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            sprite.sortingLayerName = "Player";
        }

        else if(retrieved ==false)
        {
            //transform.position = transform.position;
            sprite.sortingLayerName = "Package";
        }



        GameObject search = GameObject.FindGameObjectWithTag("Enemy");
        if (search != null)
        {
            if (boxcollid.IsTouching(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()))
            {
                if(retrieved == true)
                {
                    //this.transform.position = new Vector3(transform.position.x - 100, transform.position.y, transform.position.z);
                    //rigid.AddForce(new Vector3(transform.position.x - 10, transform.position.y + 10));
                    Debug.Log("inhand");
                    
                }

                else
                {
                    rigid.AddForce(new Vector3(transform.position.x - boxspeedx, transform.position.y + boxspeedy));
                    Debug.Log("not inhand");
                }
                    

                Debug.Log("yeet");
                
            }

        }

    }


}
