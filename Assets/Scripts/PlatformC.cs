using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlatformC : MonoBehaviour
{
    [SerializeField]private float _close;
    [SerializeField]private float _open;
    private BoxCollider2D coll;
    public LayerMask playerLayer;
    Vector2 _BoxCastSize;
    Vector2 _BoxCastCentre;
    Animator _PlatformAnimator;
    [SerializeField]AnimationClip _openingAnimation;
    [SerializeField]AnimationClip _closingAnimation;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        _BoxCastSize = new Vector2(coll.size.x -0.06f, coll.size.y -0.05f);
        _BoxCastCentre = new Vector2(coll.bounds.center.x, coll.bounds.center.y + 0.25f);
        _PlatformAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerOnPlatform()){
            StartCoroutine(Open());
        }
    }
    bool PlayerOnPlatform(){
        RaycastHit2D hit;
        if(coll.enabled ==true){
            hit = Physics2D.BoxCast(_BoxCastCentre, _BoxCastSize, 0f, Vector2.up, 0.4f,playerLayer);
            return hit;
        }
        else {
            return false;
        }
    }

    private IEnumerator Close(){
        yield return new WaitForSeconds(_close);
        _PlatformAnimator.Play("Close");
    }

    private IEnumerator Open(){
        yield return new WaitForSeconds(_open);
        _PlatformAnimator.Play("Open");
    }
}
