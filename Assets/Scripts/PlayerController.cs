using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;
    private Rigidbody2D rb;
    private SurfaceEffector2D se;
    private bool IsActive;

    float AurrekoRotazioa;
    float rotazioTotala;

    int PointsPerTxiribuelta = 100;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] public float InitialTorque { get; set; } = 50f;
    [SerializeField] public float torqueAmount { get; set; } = 50f;
    [SerializeField] float Acceleration = 1f;
    [SerializeField] float MinSpeed = 10f;
    [SerializeField] float MaxSpeed = 25f;
    bool HasSpeedPowerUP = false;

    void Start()
    {
        this.moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        se = FindObjectsByType<SurfaceEffector2D>(FindObjectsSortMode.None).First();
        this.IsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.IsActive)
        {
            Vector2 moveVector;
            moveVector = moveAction.ReadValue<Vector2>();
            RespondToAcceleration(moveVector);
            CalculateLaps();
        }
    }

    private void FixedUpdate()
    {
        if (this.IsActive)
        {
            Vector2 moveVector;
            moveVector = moveAction.ReadValue<Vector2>();
            RotatePlayer(moveVector);
        }
    }

    private void RespondToAcceleration(Vector2 moveVector)
    {
        if (moveVector.y > 0 && !HasSpeedPowerUP)
        {
            se.speed += Acceleration;
        }
        else if (moveVector.y < 0 && !HasSpeedPowerUP)
        {
            se.speed -= Acceleration;
        }

        if (se.speed < MinSpeed)
            se.speed = MinSpeed;
        if (se.speed > MaxSpeed && !HasSpeedPowerUP)
            se.speed = MaxSpeed;
    }

    private void RotatePlayer(Vector2 moveVector)
    {
        if (moveVector.x > 0)
        {
            rb.AddTorque(-torqueAmount);

        }
        else if (moveVector.x < 0)
        {
            rb.AddTorque(torqueAmount);

        }
    }

    internal void BlockControlls()
    {
        this.IsActive = false;
    }

    private void CalculateLaps()
    {
        float unekoRotazioa = transform.eulerAngles.z;
        rotazioTotala += Mathf.DeltaAngle(AurrekoRotazioa, unekoRotazioa);
        if (rotazioTotala > 340 || rotazioTotala < -340)
        {
            rotazioTotala = 0;
            scoreManager.IncrementScore(PointsPerTxiribuelta);
        }
        AurrekoRotazioa = unekoRotazioa;
    }

    public void ActivatePowerUp(PowerUpSO powerUp)
    {
        if (powerUp.GetPowerUpType == PowerUpType.Speed)
        {
            se.speed = powerUp.GetBalioa;
            HasSpeedPowerUP = true;
        }
        else if (powerUp.GetPowerUpType == PowerUpType.Torque)
        {
            this.torqueAmount = powerUp.GetBalioa;
        }
    }

    public IEnumerator DectivatePowerUp(PowerUpSO powerUp)
    {
        yield return new WaitForSeconds(powerUp.GetIraupena);
        if (powerUp.GetPowerUpType == PowerUpType.Speed)
        {
            se.speed = this.MaxSpeed;
            HasSpeedPowerUP = false;
        } else if (powerUp.GetPowerUpType == PowerUpType.Torque)
        {
            this.torqueAmount = InitialTorque;
        }
    }
}
