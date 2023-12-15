using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    Animator _cherryAnimator;
    [SerializeField]AnimationClip _cherryGot;
    // Start is called before the first frame update
    void Start()
    {
        _cherryAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            _cherryAnimator.Play("CherryGot");
            Invoke("DestroyCherry", _cherryGot.length);
        }
    }

    void DestroyCherry(){
        Destroy(gameObject);
    }
}
