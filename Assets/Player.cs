using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 2;

    }
    public PlayerStats stats = new PlayerStats();
    public int fallheight = -20;
    public int dashspeed = 20;
    public float dist;
    public float throwspeed = 10;
    public int throwx;
    public int throwy;
    public Collider2D playercollider;
    public Rigidbody2D rigi;


    private void Start()
    {
         Rigidbody2D rigi = GameObject.FindGameObjectWithTag("Package").GetComponent<Rigidbody2D>();
        playercollider = GetComponent<Collider2D>();
}
    private void Update()
    {
        if (transform.position.y <= fallheight)
        {
            DamagePlayer(2);
        }
        if (Package.retrieved==false)
            UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 20f;
        
        else 
            UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 10f;
        
        if(playercollider.IsTouching(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()))
        {
            Debug.Log("yeet");
            touchenemy();
        }
        
        dash();
        dropbox();
        throwbox();


    }

    public void DamagePlayer(int dmg)
    {
        stats.Health -= dmg;
        if (stats.Health <= 0)
        {
            Debug.Log("Kill Player");
            GM.KillPlayer(this);
        }
    }


    public void dash()
    {
        if (Input.GetKeyDown("c"))
        {
            Debug.Log("clicked");
            if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight == true)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                //UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 20f;

            }

            if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight != true)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                //UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 20f;
            }


        }
    }

    public void dropbox()
    {
        if (Input.GetKeyDown("r"))
        {


            dist = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Package").transform.position);
            if (dist < 3)
                Package.retrieved = !Package.retrieved;





        }
    }

    public void throwbox()
    {
        float step = throwspeed * Time.deltaTime;
        if (Input.GetKeyDown("t"))
        {
            if (Package.retrieved == true)
            {
                //GameObject.FindGameObjectWithTag("Package").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("Package").transform.position, new Vector3(transform.position.x+10, transform.position.y), step);

                //rigi.AddForce(new Vector3(GameObject.FindGameObjectWithTag("Package").transform.position.x + throwx, GameObject.FindGameObjectWithTag("Package").transform.position.y +throwy));
                if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight)
                    rigi.AddForce(new Vector3(transform.position.x + throwx, transform.position.y + throwy));
                if (!gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight)
                    rigi.AddForce(new Vector3(transform.position.x - throwx, transform.position.y + throwy));


                Package.retrieved = false;
            }
        }

    }

    public void touchenemy()
    {
        if (Package.retrieved)
        Package.retrieved = false;

        else if (!Package.retrieved)
        {

        }
    }
}
