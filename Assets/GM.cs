using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public static GM gm;

    private void Start()
    {
        if(gm==null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawntime = 2;

    public IEnumerator Respawn()
    {
        Debug.Log("respawning");
        yield return new WaitForSeconds(spawntime);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("Respawned");
    }
    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        Debug.Log("killed");
        gm.StartCoroutine(gm.Respawn()); 
        
    }

 
}
