using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    public UnitAnimHandler unitAnimHandler;
    public UnitSpriteHandler unitSpriteHandler;


    protected StatHandler statHandler;

    protected bool isAttacking;
    private float timeSinceLastAttack = float.MaxValue;

    public GameObject ride;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        unitAnimHandler = GetComponent<UnitAnimHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        HandleAttackDelay();
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    private void Movment(Vector2 direction)
    {
        direction = direction * statHandler.Speed;
        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
        if (direction.magnitude < 0.1f)
        {
            unitAnimHandler.PlayAnimation(UnitAnimState.IDLE, 0);
        }
        else
        {
            if (!ride.activeSelf)
            {
                unitAnimHandler.PlayAnimation(UnitAnimState.MOVE, 0);
            }
            else
            {
                _rigidbody.velocity = direction * 2;
                unitAnimHandler.PlayAnimation(UnitAnimState.IDLE, 0);
            }
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        if (isLeft) transform.localScale = new Vector3(1, 1, 1);
        else transform.localScale = new Vector3(-1, 1, 1);
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    private void HandleAttackDelay()
    {
        // if (weaponHandler == null)
        //     return;

        // if (timeSinceLastAttack <= weaponHandler.Delay)
        // {
        //     timeSinceLastAttack += Time.deltaTime;
        // }

        // if (isAttacking && timeSinceLastAttack > weaponHandler.Delay)
        // {
        //     timeSinceLastAttack = 0;
        //     Attack();
        // }
    }

    protected virtual void Attack()
    {
        // if (lookDirection != Vector2.zero)
        //     weaponHandler?.Attack();
    }

    public virtual void Death()
    {
        // _rigidbody.velocity = Vector3.zero;

        // foreach (SpriteRenderer renderer in transform.GetComponentsInChildren<SpriteRenderer>())
        // {
        //     Color color = renderer.color;
        //     color.a = 0.3f;
        //     renderer.color = color;
        // }

        // foreach (Behaviour component in transform.GetComponentsInChildren<Behaviour>())
        // {
        //     component.enabled = false;
        // }

        // Destroy(gameObject, 2f);
    }
}