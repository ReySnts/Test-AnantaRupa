using UnityEngine;

public sealed class ControllerMove : AbstractController
{
    [SerializeField] private float units = 3f;

    [SerializeField] private bool logicIsStarted;

    [SerializeField] private bool isOnLeft;

    private Transform _transform;

    private Transform player;

    private Vector3 target;

    protected override void Awake()
    {
        _transform = transform.parent;
        player = _transform.parent.parent.GetComponentInChildren<InteractorPlayer>().transform;
    }

    public override void DoLogic()
    {
        logicIsStarted = true;
        isOnLeft = _transform.position.x - player.position.x < 0f;
        target = _transform.position + Vector3.right * (isOnLeft ? -units : units);
    }

    private void Update()
    {
        if (logicIsStarted)
        {
            var distance = Vector3.Distance(a: _transform.position, b: target);
            if (distance == 0) logicIsStarted = false;
            else _transform.position = Vector3.MoveTowards(current: _transform.position, target, maxDistanceDelta: 10f * Time.deltaTime);
        }
    }
}