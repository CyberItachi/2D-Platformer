using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]private float speed = 10f;
    Vector3 targetPos;

    [SerializeField]private GameObject ways;
    [SerializeField]private Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;
    [SerializeField]private bool loop;

    private void Awake() {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i<ways.gameObject.transform.childCount; i++){
            wayPoints[i]=ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start() {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    private void Update() {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if(transform.position == targetPos){
            NextPoint();
        }
    }

    private void NextPoint(){

        
        if(pointIndex == pointCount-1){
            if(loop==true){
            direction = -(pointCount -1);
        }
        else
            direction = -1;
        }

        if(pointIndex==0){
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
}
