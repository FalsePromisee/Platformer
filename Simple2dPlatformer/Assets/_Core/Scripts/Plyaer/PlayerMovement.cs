using UnityEngine;

namespace _Core.Scripts.Plyaer
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _jumpForce = 20f;
        private float jumpCooldown = .2f;
        private float jumpCurrentCD = 0;
    
        private Vector2 _currentVelocity;
    
        private Animator _animator;
        private Rigidbody2D _rigidbody;
    
        private float _playerDirectionX;
        private bool _isLookingRight = true;
        private bool _isGrounded;
        private LayerMask _groundLayer;
 
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _groundLayer = LayerMask.GetMask("Ground");
        }

        private void Update()
        {
            _playerDirectionX = Input.GetAxis("Horizontal");
            MoveAnimation();
            Jump();
        
        }

        private void Jump()
        {
            jumpCurrentCD -= Time.deltaTime;
            
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && jumpCurrentCD <= 0)
            {
                _rigidbody.AddForceY(_jumpForce, ForceMode2D.Impulse);
                jumpCurrentCD = jumpCooldown;
            }
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = new Vector2((_playerDirectionX * _speed) * Time.fixedDeltaTime, _rigidbody.linearVelocity.y);
        
        }

        private void MoveAnimation()
        {
            if (_playerDirectionX > 0)
            {
                _isLookingRight = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (_playerDirectionX < 0)
            {
                _isLookingRight = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (_isLookingRight)
            {
                _animator.SetFloat("PlayerVelocity", _playerDirectionX);   
            }
            else if (!_isLookingRight)
            {
                _animator.SetFloat("PlayerVelocity", -_playerDirectionX);
            }
        }

    

        private bool IsGrounded()
        {
            //float rayOffset = 1.5f;
            //float rayDistance = 1f;
            Vector2 capsuleSize = new Vector2(0.7f, 1f);
            float capsuleAngle = 0f;
            float capsuleDistance = 0.1f;
            return Physics2D.CapsuleCast(transform.position, capsuleSize, CapsuleDirection2D.Vertical, capsuleAngle, Vector2.down, capsuleDistance,
                _groundLayer);
            //return Physics2D.Raycast(transform.position, Vector2.down * rayOffset, rayDistance, LayerMask.GetMask("Ground") );
        
        }
    
    
    
    }
}
