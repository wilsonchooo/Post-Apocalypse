using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight == true)
        {
            rb.velocity = transform.right * speed;

        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight == false)

        {
            rb.velocity = -transform.right * speed;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy!=null)
        {
            enemy.health = enemy.health - 1;
        }
        Destroy(gameObject);
    }

    // Update is called once per frame

}
