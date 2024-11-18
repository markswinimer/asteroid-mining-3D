using UnityEngine;
using System.Collections.Generic; // for lists

public class Enemy : Core {
    public int health;
    public int damage;
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float attackChargeTime;
    public float attackCooldownTime;
    public float attackDamage;

    [SerializeField] private IdleState IdleState;
    [SerializeField] private PatrolState PatrolState;
    [SerializeField] private ChaseAttackState ChaseAttackState;

    public State StartingState;

    private Transform PlayerShip;

    private float _health = 100;

    void Start()
    {
        PlayerShip = FindFirstObjectByType<PlayerShip>().transform;
        SetupInstances();
        Set(StartingState);
    }

    void Update()
    {
        if (state.isComplete)
        {
            if (state == ChaseAttackState)
            {
                Set(PatrolState);
            }
        }

        if (state == PatrolState)
        {
            ChaseAttackState.CheckForTarget();
            if (ChaseAttackState.target != null)
            {
                Set(ChaseAttackState, true);
            }
        }

        state.DoBranch();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        state.FixedDoBranch();
    }

    void OnDrawGizmos()
    {
#if UNITY_EDITOR
        if (Application.isPlaying && state != null)
        {
            List<State> states = machine.GetActiveStateBranch();
            UnityEditor.Handles.Label(new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), "Active States: " + string.Join(", ", states));
        }
#endif
    }
}