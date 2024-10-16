using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] Camera playerCam;

    [SerializeField] float defaultDistance = 10f;

    [SerializeField] LayerMask cubeFilter;
    [SerializeField] LayerMask Ground;

    private void Start()
    {
        playerCam = Camera.main;
    }


    private void FixedUpdate()
    {
        float distance = defaultDistance;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, 10, Ground.value))
        {
            distance = hit.distance;
        }
        Debug.Log($"Distance is {distance}");

        Vector3 camPos = playerCam.transform.position;
        Debug.DrawLine(camPos, camPos + playerCam.transform.forward * 10, Color.red);

        RaycastHit[] hits = Physics.RaycastAll(playerCam.transform.position, playerCam.transform.forward, distance, cubeFilter.value);
        foreach(RaycastHit hit2 in hits)
        {
            if(hit2.collider.TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.red;
            }
        }
    }
}
