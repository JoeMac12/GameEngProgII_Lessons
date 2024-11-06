using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public CameraManager cameraManager;
    public Camera playerCam;
    public int maxRayDistance;

    public UIManager uIManager;
    [SerializeField]

    private GameObject target;

    private Interactable targetInteractable;

    public bool interactionPossible;

    void Awake()
    {
        playerCam = cameraManager.playerCamera;
        uIManager = FindObjectOfType<UIManager>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    void Update()
    {
        if (target != null)
        {
            interactionPossible = true;
        }
        else
        {
            interactionPossible = false;
        }
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, maxRayDistance))
        {
            if (hit.transform.gameObject.CompareTag("Interact"))
            {
                Debug.Log("Looking at " + hit.transform.gameObject.name);
                target = hit.transform.gameObject;
                targetInteractable = target.GetComponent<Interactable>();
            }
            else
            {
                target = null;
                targetInteractable = null;
            }

            SetGameplayMessage();

        }
    }

    public void Interact()
    {
        switch (targetInteractable.type)
        {
            case Interactable.InteractionType.Door:
                target.SetActive(false);
                break;
            case Interactable.InteractionType.Button:
                break;
            case Interactable.InteractionType.Pickup:
                break;

        }
    }

    void SetGameplayMessage()
    {
        string message = "";
        if (target != null)
        {
            switch (targetInteractable.type)
            {
                case Interactable.InteractionType.Door:
                    message = "Press LMB to open door!";
                    break;
                case Interactable.InteractionType.Button:
                    break;
                case Interactable.InteractionType.Pickup:
                    break;
            }

        }
        uIManager.UpdateGamePlayMessage(message);
    }
}
