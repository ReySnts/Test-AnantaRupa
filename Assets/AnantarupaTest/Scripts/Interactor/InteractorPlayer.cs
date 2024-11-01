using System.Linq;
using UnityEngine;

public sealed class InteractorPlayer : MonoBehaviour
{
    [SerializeField] private AbstractInteractable nearestInteractableObject;

    [SerializeField] private bool nearestInteractableObjectIsTriggered;

    private InputManager inputManager;

    private void Awake() => inputManager = GetComponentInParent<InputManager>();

    private void FixedUpdate()
    {
        var interactableObjects = FindObjectsOfType<AbstractInteractable>();
        nearestInteractableObject = interactableObjects.
            OrderBy(keySelector: interactableObject =>
            Vector3.Distance(a: transform.position, b: interactableObject.transform.position)
            ).FirstOrDefault();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag: Tag.INTERACTABLE))
        {
            var otherInteractable = other.GetComponent<AbstractInteractable>();
            if (otherInteractable == nearestInteractableObject) nearestInteractableObjectIsTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag: Tag.INTERACTABLE))
        {
            var otherInteractable = other.GetComponent<AbstractInteractable>();
            if (otherInteractable == nearestInteractableObject) nearestInteractableObjectIsTriggered = false;
        }
    }

    private void Update()
    {
        if (nearestInteractableObjectIsTriggered && nearestInteractableObject.Interactor.CanBeInteracted && inputManager.GetKeyDownE)
        {
            var interactionObserver = nearestInteractableObject.GetComponentInParent<AbstractObserver>();
            nearestInteractableObject.Controller.DoLogic();
            interactionObserver.Invoke();
        }
    }
}