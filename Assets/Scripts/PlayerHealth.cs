using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _PlayerHealth;
    [SerializeField] int _NoOfHearts;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite _FullHeart;
    [SerializeField] Sprite _EmptyHeart;
    Vector3 _LastCheckPoint;
    public static PlayerHealth instance;

    private void Start() {
        if(_NoOfHearts>_PlayerHealth){
            _NoOfHearts = _PlayerHealth;
        }
        if(instance == null){ 
            instance = this;
        }

        _LastCheckPoint = transform.position;
    }
    private void Update() {
        
        for(int i=0; i<hearts.Length; i++){
            if(i<_PlayerHealth){
                hearts[i].sprite = _FullHeart;
            }
            else{
                hearts[i].sprite = _EmptyHeart;
            }
            if(i<_NoOfHearts){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("CheckPoint")){
            _LastCheckPoint = other.transform.position;
        }
    }

    public void TakeDamage(int damage){
        _PlayerHealth -= damage;
        transform.position = _LastCheckPoint;
    }

    public void Death(){
        if(_PlayerHealth<=0){
            Debug.Log("player died");
        }
    }
}
