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

    private void Update()
    {
        if (transform.position.y <= fallheight)
        {
            DamagePlayer(2);
        }

        dash();
    }

    public void DamagePlayer (int dmg)
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
            if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight== true)
            {
                transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }

            if (gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_FacingRight != true)
            {
                transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }


        }
    }
    
}
