using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]int _Damage = 1;
    
    private void Start() {
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")){
            DealDamage(_Damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DealDamage(_Damage);
        }
    }
    void DealDamage(int _DamagetoDeal){
        PlayerHealth.instance.TakeDamage(_DamagetoDeal);
    }
}
