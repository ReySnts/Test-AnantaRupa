using UnityEngine;

public sealed class InteractorObject : AbstractInteractor
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag: Tag.PLAYER)) IsTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag: Tag.PLAYER)) IsTriggered = false;
    }
}