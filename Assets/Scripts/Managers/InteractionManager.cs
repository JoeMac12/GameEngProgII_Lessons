using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public CameraManager cameraManager;
    public Camera playerCam;
    public UIManager uIManager;

    public int maxRayDistance;

    [SerializeField]
    private GameObject target;

    private Interactable targetInteractable;

    public bool _interactionPossible;

    void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerCam = cameraManager.playerCamera;

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            _interactionPossible = true;
        }
        else
        {
            _interactionPossible = false;
        }
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out RaycastHit hit, maxRayDistance))
        {
            if (hit.transform.gameObject.CompareTag("Interactable"))
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
                target.SetActive(false);
                Debug.Log("Button Pressed!");
                break;
            case Interactable.InteractionType.Pickup:
                target.SetActive(false);
                Debug.Log("Picked up item!");
                break;
        }
    }

    void SetGameplayMessage()
    {
        string message = "";
        if (targetInteractable == null) return;

            switch (targetInteractable.type)
            {
                case Interactable.InteractionType.Door:
                message = "Press LMB to open door";
                break;
                case Interactable.InteractionType.Button:
                message = "Press LMB to press button";
                break;
                case Interactable.InteractionType.Pickup:
                message = "Press LMB to pickup item";
                break;
            }

        uIManager.UpdateGameplayMessage(message);
    }
}
