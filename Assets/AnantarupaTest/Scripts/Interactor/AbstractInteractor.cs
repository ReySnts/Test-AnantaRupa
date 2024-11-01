using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractInteractor : MonoBehaviour
{
    [field: SerializeField] public bool CanBeInteracted { get; private set; } = true;

    [field: SerializeField] public bool IsTriggered { get; protected set; }

    private AbstractObserver observer;

    private void Awake() => observer = GetComponentInParent<AbstractObserver>();

    private void OnEnable() => observer.Event += Cooldown;

    private async void Cooldown()
    {
        if (destroyCancellationToken.IsCancellationRequested) return;
        CanBeInteracted = false;
        await Task.Delay(millisecondsDelay: 1000);
        CanBeInteracted = true;
    }

    private void OnDisable() => observer.Event -= Cooldown;
}