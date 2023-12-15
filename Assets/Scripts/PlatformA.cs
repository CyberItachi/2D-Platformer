using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformA : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        player = PlayerMovement.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>=player.transform.position.y){
            boxCollider2D.enabled = false;
        }
        else{
            boxCollider2D.enabled = true;
        }
    }
}
