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



        if (boxcollid.IsTouching(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()))
        {
            Debug.Log("yeet");
            rigid.AddForce(new Vector3(transform.position.x - boxspeedx, transform.position.y + boxspeedy));
        }

    }


}
