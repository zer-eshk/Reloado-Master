using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    private Camera mainCam;
    private Vector2 mousePos;
     private float rotZ;
    // Start is called before the first frame update
    void Start()
    {
        mainCam=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir=mousePos-rb.position;
        rotZ=math.atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;

        rb.rotation = rotZ;
    }
    private void FixedUpdate()
    {
        rb.rotation = rotZ;
    }
}
