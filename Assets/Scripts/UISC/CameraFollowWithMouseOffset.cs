using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWithMouseOffset : MonoBehaviour
{
    public Transform player;
    public float offsetStrength = 3f;

    private CinemachineVirtualCamera vCam;
    private CinemachineFramingTransposer transposer;
    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        vCam = GetComponent<CinemachineVirtualCamera>();
        transposer = vCam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void LateUpdate()
    {
        if (player == null || transposer == null) return;

        Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offsetDir = (mouseWorldPos - player.position).normalized;

        Vector2 offset = new Vector2(offsetDir.x, offsetDir.y) * offsetStrength;
        transposer.m_TrackedObjectOffset = offset;
    }
}

