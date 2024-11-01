using System.Threading.Tasks;
using UnityEngine;

public sealed class ControllerText : AbstractController
{
    private GameObject greeting;

    protected override void Awake()
    {
        greeting = transform.parent.GetChild(index: 1).GetChild(index: 0).GetChild(index: 1).gameObject;
        greeting.SetActive(value: false);
    }

    public override async void DoLogic()
    {
        if (destroyCancellationToken.IsCancellationRequested) return;
        greeting.SetActive(value: true);
        await Task.Delay(millisecondsDelay: 1000);
        greeting.SetActive(value: false);
    }
}