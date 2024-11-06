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
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Plane on the XZ plane at y = 0
        if (groundPlane.Raycast(ray, out float distance))
        {
            // Get the point on the ground plane where the ray intersects
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 aimDirection = (targetPoint - transform.position).normalized;

            // Rotate the weapon mount to face the target point
            Quaternion targetRotation = Quaternion.LookRotation(aimDirection, Vector3.up);
            _mountedWeapon.transform.rotation = targetRotation;
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
