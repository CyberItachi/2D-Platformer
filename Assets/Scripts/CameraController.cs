using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public SpriteRenderer _Background;
    private Vector3 bottomLeftCorner;
    private Vector3 bottomRightCorner;
    [SerializeField]private float verticalOffset;
    [SerializeField]private float horOffset;

    private float halfHeight;
    private float halfWidth;
    private bool playerSpriteX;
    private Camera mCamera;
    public float SmoothTime;
    public float cameraOffset;
    private float HV_ease;
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
        if(target ==null){target = PlayerMovement.instance.transform;}
        
        bottomLeftCorner = _Background.bounds.min + new Vector3(halfWidth, halfHeight, 0f);
        bottomRightCorner = _Background.bounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
        PlayerMovement.instance.SetBounds(_Background.bounds.min, _Background.bounds.max);
        HV_ease = target.GetComponent<Rigidbody2D>().velocity.x;

    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(target.transform.position.x+cameraOffset,transform.position.y,transform.position.z),ref velocity,SmoothTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftCorner.x, bottomRightCorner.x),
            Mathf.Clamp(transform.position.y, bottomLeftCorner.y, bottomRightCorner.y),
            transform.position.z);
    }
    }
