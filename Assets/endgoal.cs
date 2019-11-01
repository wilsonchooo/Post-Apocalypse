using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endgoal : MonoBehaviour
{
    public GameObject package;
    // Start is called before the first frame update
    void Start()
    {
        package = GameObject.FindGameObjectWithTag("Package");

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Collider2D>() != null && GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>() != null)
        {

            if (this.GetComponent<Collider2D>().IsTouching(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>()) && Package.retrieved == true)
            {
                Debug.Log("YOU WIN BRO");
            }
        }

    }
}
