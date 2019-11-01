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
    public float dist2;
    public float enemydist;
    public float throwspeed = 10;
    public int throwx;
    public int throwy;
    public Collider2D playercollider;
    public Rigidbody2D rigi;
    public SpriteRenderer render;
    public Enemy enemy;
    public GameObject package;
    public bool iframe;
    public Animator anim;
    

    private void Start()
    {
        rigi = GameObject.FindGameObjectWithTag("Package").GetComponent<Rigidbody2D>();
        package = GameObject.FindGameObjectWithTag("Package");
        playercollider = GetComponent<Collider2D>();
        render = this.transform.Find("Graphics").GetComponent<SpriteRenderer>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        iframe = false;
        anim = this.GetComponent<Animator>();

        

    }
    private void Update()
    {
        if (transform.position.y <= fallheight)
        {
            DamagePlayer(2);
        }
        if (Package.retrieved==false)
            UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 15f;
        
        else 
            UnityStandardAssets._2D.PlatformerCharacter2D.m_MaxSpeed = 10f;

  
        GameObject search = GameObject.FindGameObjectWithTag("Enemy");
        if (search != null)
        {
            dist2 = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
            if (playercollider.IsTouching(GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()))
            {         
                Debug.Log("yeet");
                touchenemy();
                StartCoroutine(iframes());
            }
        }

       

        dash();
        
        
        dropbox();
        throwbox();
        dmgenemy();

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
            
            if (dist2 <= 7 && enemy.health == 1)
            {
                anim.SetTrigger("Attack");
                Debug.Log("working");
                enemy.health = 0;
                
                if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight == true)
                {
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Enemy").transform.position.x + 5, transform.position.y, transform.position.z);
                }

                if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight != true)
                {
                    transform.position = new Vector3(GameObject.FindGameObjectWithTag("Enemy").transform.position.x - 5, transform.position.y, transform.position.z);
                }
                StartCoroutine(dashdelay(100.0f));
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
        Rigidbody2D rigi = GameObject.FindGameObjectWithTag("Package").GetComponent<Rigidbody2D>();
        float step = throwspeed * Time.deltaTime;
        if (Input.GetKeyDown("t"))
        {
            if (Package.retrieved == true)
            {
                //GameObject.FindGameObjectWithTag("Package").transform.position = Vector3.MoveTowards(GameObject.FindGameObjectWithTag("Package").transform.position, new Vector3(transform.position.x+10, transform.position.y), step);

                //rigi.AddForce(new Vector3(GameObject.FindGameObjectWithTag("Package").transform.position.x + throwx, GameObject.FindGameObjectWithTag("Package").transform.position.y +throwy));
                if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight)
                    rigi.AddForce(new Vector3(transform.position.x + 500, transform.position.y + 500));
                if (!gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight)
                    rigi.AddForce(new Vector3(transform.position.x - 500, transform.position.y + 500));

                Package.retrieved = false;
            }
        }

    }

    public void touchenemy()
    {
        if (!iframe)
        {
            if (Package.retrieved)
            {
                Debug.Log("iframe not active");
                package.transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
                Package.retrieved = false;


                //package.transform.position = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
                //rigi.AddForce(new Vector3(transform.position.x - 500, transform.position.y + 500));
            }


            else if (!Package.retrieved)
            {
                DamagePlayer(2);
                Debug.Log("Game Over");
            }
        }
        else
        {};
    }
    public void dmgenemy()
    {
        if (Input.GetKeyDown("p"))
        {
            Debug.Log(enemy.health);
            enemy.health = enemy.health - 1;
            Debug.Log(enemy.health);
        }
    }

    IEnumerator iframes()
    {
        iframe = true;
        yield return new WaitForSeconds(3);
        iframe = false;
    }

    IEnumerator dashdelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        
    }
}
