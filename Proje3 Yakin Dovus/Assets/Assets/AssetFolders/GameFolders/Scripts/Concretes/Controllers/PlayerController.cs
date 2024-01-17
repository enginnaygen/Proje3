using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Inputs;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Combats;
using UdemyProject3.Inputs;
using UdemyProject3.Movements;
using UdemyProject3.StatesMachines.EnemyStates;
using UnityEngine;
using UnityEngine.UI;


namespace UdemyProject3.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IplayerInputs _input;
        IMover _mover;
        IMyAnimation _animation;
        Transform _transform;
        IFlip _flip;
        IJump _jump;
        Health _health;
        OnGround _ground;
        //BoxCollider2D _collider;

        float _time=0.5f;
        bool _jumped=false;
        float _horizontal;
        [SerializeField] float _jumpSpeed;
        [SerializeField] float moveSpeed;

        public float Score { get; set; }
        [SerializeField] Text scoreText;




        private void Awake()
        {
            _input = new PcInput();
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _transform = GetComponent<Transform>();
            _flip = new FlipWithTransform(_transform);
            _jump = new Jump(GetComponent<Rigidbody2D>());
            _ground = GetComponent<OnGround>();
            _health = GetComponent<Health>();
           // _collider = GetComponent<BoxCollider2D>();
        }
        private void Start()
        {
            if (PlayerPrefs.HasKey("Score"))
            { Score = PlayerPrefs.GetInt("Score"); }
            else
            {
                Score = 0;
            }
        }

        private void OnEnable()
        {
           
            _health.OnDead += _animation.DeadAnimation;
        }


        private void Update()
        {
            PlayerPrefs.SetInt("Score", (int)Score);
            scoreText.text = "" + Score;

            if (_health.IsDead) return;
            _time += Time.deltaTime;
            _horizontal = _input.Horizontal;
            if (_input.AttackButton && _time>0.5f)
            {
                _animation.AttackAnimation(); 
                _time = 0f;
                return;
                
            }

            if (_input.IsJump && _ground.onGround)
            {
                _jumped = true;
            }

            _animation.JumpAnimation(!_ground.onGround);
            _animation.MoveAnimation(_horizontal);

            



           

           

        }

        private void FixedUpdate()
        {
            _mover.PlayerMove(_horizontal);
            _flip.Turn(_horizontal);

            if (_jumped)
            {
                _jump.JumpAction(_jumpSpeed); //&&_ground.onGround buraya eklenirse havadan yere inildiði gibi zýplar
                _jumped = false;
            }
           

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag=="elmas")
            {
                Score +=10;
                Destroy(collision.gameObject);
                PlayerPrefs.SetInt("Score", (int)Score);

            }
            if (collision.tag=="Dead")
            {
                _animation.DeadAnimation();
                _health.currentHealt = 0;
                PlayerPrefs.SetInt("Score", (int)Score);

            }
        }


    }

}
