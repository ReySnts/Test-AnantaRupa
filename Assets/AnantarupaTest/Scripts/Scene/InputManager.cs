using UnityEngine;

public sealed class InputManager : MonoBehaviour
{
    public bool GetKeyA => Input.GetKey(key: KeyCode.A);

    public bool GetKeyD => Input.GetKey(key: KeyCode.D);

    public bool GetKeyDownE => Input.GetKeyDown(key: KeyCode.E);
}