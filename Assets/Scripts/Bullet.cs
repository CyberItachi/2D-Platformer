using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 1f;
    [SerializeField] ParticleSystem _bulletBreak;
    SpriteRenderer _bulletSprite;
    public bool isLeft;
    [Range(0f,10f)]
    [SerializeField] float _lifeTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        _bulletSprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLeft)
        transform.Translate(_bulletSpeed,0,0);
        else
        transform.Translate(-_bulletSpeed,0,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        _bulletSpeed = 0;
        _bulletBreak.Play();
        _bulletSprite.enabled = false;
        Invoke("DestroyBullet", 0.2f);
    }

    private void DestroyBullet(){
        Destroy(gameObject);
    }
    
}
