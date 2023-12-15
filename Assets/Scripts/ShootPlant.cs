using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShootPlant : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    private Animator _PlantAnimator;
    
    private void Start() {
        _PlantAnimator = GetComponent<Animator>();
    }

    private void Attack(){
        Instantiate(_bullet,transform.GetChild(0).position, quaternion.identity);
    }
}
