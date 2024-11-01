using UnityEngine;

[RequireComponent(requiredComponent: typeof(AbstractInteractor))]

public abstract class AbstractInteractable : MonoBehaviour
{
    public AbstractController Controller { get; private set; }

    public AbstractInteractor Interactor { get; private set; }

    private void Awake()
    {
        Controller = GetComponentInChildren<AbstractController>();
        Interactor = GetComponent<AbstractInteractor>();
    }
}