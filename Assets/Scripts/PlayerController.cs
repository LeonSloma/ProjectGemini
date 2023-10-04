using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using static System.Math;

/// <summary>
/// Class <c>PlayerController</c>, derives from <c>MonoBehaviour</c>.
/// Handles all player actions.
/// </summary>
public class PlayerController : MonoBehaviour
{

    protected static List<PlayerController> players = new List<PlayerController>();

    public int health = 3;
    public float speed = 10;
    public float jumpForce = 200;
    public bool flippedY = false;
    public bool flippedX = false;
    public float gravityScale = 1;

    [SerializeField]
    protected Transform groundOverlapTopLeft;
    [SerializeField]
    protected Transform groundOverlapBottomRight;
    [SerializeField]
    protected GameObject pivot;
    [SerializeField]
    protected LayerMask groundLayer;
    [SerializeField]
    protected PauseMenu pauseMenu;
    


    private bool _grounded = false;
    private Interactable _interactable;
    private float _forceX = 0;

    private Rigidbody2D _body;
    private Animator _animator;
    private SpriteRenderer _sprite;

    public static void FlipPlayersVertical()
    {
        players.ForEach( FlipVertical );
    }
    
    public static void FlipVertical(PlayerController p)
    {   
        p.FlipVertical();
    }
    
    public void FlipVertical()
    {
        Vector3 s = _body.transform.localScale;
        gravityScale *= -1;
        jumpForce *= -1;
        flippedY = !flippedY;
        pivot.transform.Rotate( new Vector3(0,0, flippedY ? -180 : 180));
    }

    public void FlipHorizontal(int direction)
    {
        flippedX = !flippedX;
        pivot.transform.Rotate( new Vector3(0,0, flippedX ? -90 : 90));
        if (direction == -1) {
            FlipVertical();
        }
    }

    
    public void SetInteractable( Interactable i )
    {
        _interactable = i;
    }

    public void ClearInteractable() 
    {
        _interactable = null;
    }

    public void OnInteract()
    {
        if (_interactable != null) _interactable.Interact();
    }
    
    public void OnMove( InputValue input )
    {
        _forceX = speed * input.Get<float>();
        _sprite.flipX = _forceX < 0;
        if (flippedY) _sprite.flipX = !_sprite.flipX;
        if (flippedX && flippedY) _forceX *= -1;
    }

    public void OnPause()
    {
        pauseMenu.showPauseMenu();
    }

    public void die()
    {
        this.gameObject.SetActive(false);
        pauseMenu.showGameOverMenu();
    }

    void Start()
    {
        _body = GetComponentInChildren<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        players.Add(this);

        if (flippedY)
        {
            FlipVertical();
            flippedY = true;
        }
        if (flippedX)
        {
            flippedX = false;
            FlipHorizontal(1);
        }

    }

    void FixedUpdate()
    {
        _grounded = Physics2D.OverlapArea(groundOverlapTopLeft.position, groundOverlapBottomRight.position, groundLayer);
        _animator.SetBool("grounded", _grounded);
        _animator.SetFloat("velocityX", Abs(_forceX));

        if (flippedX)
        {
            float velY = _body.velocity.x - (9.98f * gravityScale * Time.deltaTime);
            _body.velocity = new Vector3(velY, -_forceX);
        }
        else
        {
            float velY = _body.velocity.y - (9.98f * gravityScale * Time.deltaTime);
            _body.velocity = new Vector3(_forceX, velY);
        }
    }

    void OnDestroy()
    {
        PlayerController.players.Clear();
    }
}

