using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int walkspeed;
    public GameObject player;
    public GameObject package;
    public bool range;
    float MoveSpeed = 3f;
    public float dist;
    public SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        render = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        package = GameObject.FindGameObjectWithTag("Package");

    }

    // Update is called once per frame
    void Update()
    {
        if (health == 1)
            render.color = new Color(255, 0, 0);
        if (health == 0)
            Destroy(this.gameObject);

        GameObject search = GameObject.FindGameObjectWithTag("Player");
        if (search != null)
        {
            transform.LookAt(search.transform);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            dist = Vector3.Distance(transform.position, search.transform.position);

            if (dist < 10)
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
        
    }
}
    

