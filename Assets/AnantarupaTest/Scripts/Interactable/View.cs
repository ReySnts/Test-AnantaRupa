using UnityEngine;

public sealed class View : MonoBehaviour
{
    private AbstractInteractor interactor;

    private GameObject clickable;

    private GameObject text_X;

    private void Awake()
    {
        interactor = GetComponentInParent<AbstractInteractor>();
        clickable = transform.GetChild(index: 0).GetChild(index: 0).gameObject;
        text_X = clickable.transform.GetChild(index: 2).gameObject;
    }

    private void Update()
    {
        clickable.SetActive(value: interactor.IsTriggered);
        text_X.SetActive(value: !interactor.CanBeInteracted);
    }
}