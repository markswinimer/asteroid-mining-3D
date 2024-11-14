using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponMount : MonoBehaviour
{
    public Weapon _mountedWeapon;

    private float _shootDelay;
    private float _timeToShoot;

    InputAction primaryAction;
    InputAction secondaryAction;

    private void Awake()
    {
        primaryAction = InputSystem.actions.FindAction("PrimaryAction");
        secondaryAction = InputSystem.actions.FindAction("SecondaryAction");
    }

    void Start()
    {
        _shootDelay = _mountedWeapon.fireRate;
        _timeToShoot = 0f;
    }

    void Update()
    {
        _timeToShoot -= Time.deltaTime;

        HandleDirection();
        HandleInput();
    }

    void HandleDirection()
    {
        // Get the mouse position on the screen
        Vector3 mousePos = Input.mousePosition;

        // Cast a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        // Define the ground plane based on the weapon mount's height to better match its position
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, _mountedWeapon.transform.position.y, 0));
        if (groundPlane.Raycast(ray, out float distance))
        {
            // Get the intersection point with the ground plane at the weapon's height
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 aimDirection = (targetPoint - _mountedWeapon.transform.position).normalized;

            // Rotate the weapon mount to face the target point
            Quaternion targetRotation = Quaternion.LookRotation(aimDirection, Vector3.up);
            _mountedWeapon.transform.rotation = targetRotation;

            // Freeze rotation on unwanted axes
            _mountedWeapon.transform.eulerAngles = new Vector3(0, _mountedWeapon.transform.eulerAngles.y, 0);
        }
    }

    void HandleInput()
    {
        if (primaryAction.IsPressed() && _timeToShoot <= 0f)
        {
            _timeToShoot = _shootDelay;
            _mountedWeapon.PrimaryAction();
        }
        else if (secondaryAction.IsPressed())
        {
            _mountedWeapon.SecondaryAction();
        }
    }
}
