using UnityEngine;

public sealed class ControllerResize : AbstractController
{
    [SerializeField] private float positionY = 1f;

    [SerializeField] private float resizeMultiplier = 2f;

    [SerializeField] private bool hasBeenResized;

    private Transform _transform;

    protected override void Awake() => _transform = transform.parent;

    public override void DoLogic()
    {
        var positionY = hasBeenResized ? -this.positionY : this.positionY;
        var resizeMultiplier = hasBeenResized ? 1 / this.resizeMultiplier : this.resizeMultiplier;
        _transform.position = new Vector3(_transform.position.x, _transform.position.y + positionY, _transform.position.z);
        _transform.localScale *= resizeMultiplier;
        hasBeenResized = !hasBeenResized;
    }
}