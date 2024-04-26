using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed, acceleration;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 currentVelocity;

    // Reference to the generated input actions class
    private PlayerControls controls;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // Sprites for each direction
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    public Tilemap terrainTilemap;       // Reference to the tilemap containing different terrains
    public TileBase roadTile, grassTile;            // Reference to the road tile
    [SerializeField] private float roadSpeed, grassSpeed;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Move.performed += OnMovePerformed;
        controls.Gameplay.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        controls.Gameplay.Move.performed -= OnMovePerformed;
        controls.Gameplay.Move.canceled -= OnMoveCanceled;
        controls.Gameplay.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        UpdateSpriteDirection();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        movement = Vector2.zero;
    }

    private void Update(){
        UpdateSpeed();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = movement * maxSpeed;
        // Smoothly interpolate from current velocity to target velocity
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }

    void UpdateSpeed()
    {
        Vector3Int cellPosition = terrainTilemap.WorldToCell(transform.position);
        TileBase currentTile = terrainTilemap.GetTile(cellPosition);

        if (currentTile == roadTile)
        {
            // Increase speed on road
           maxSpeed = roadSpeed;
        }
        else if (currentTile == grassTile)
        {
            // Reduce speed on grass
            maxSpeed = grassSpeed;
        }
        else
        {
            maxSpeed = 3;
        }
    }

    private void UpdateSpriteDirection()
    {
        // Change the sprite based on the direction of movement
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            // Horizontal movement
            spriteRenderer.sprite = movement.x > 0 ? rightSprite : leftSprite;
        }
        else if (Mathf.Abs(movement.y) > 0)
        {
            // Vertical movement
            spriteRenderer.sprite = movement.y > 0 ? upSprite : downSprite;
        }
    }

}
