using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Movements;
using UdemyProject3.StatesMachines;
using UdemyProject3.StatesMachines.EnemyStates;
using UnityEngine;


namespace UdemyProject3.Controllers
{
    public class EnemyController : MonoBehaviour
    {

        //IMover mover;
        //IMyAnimation animation;  bunların referanslarını ayrıca nurada tutmamıza gerek olmadığından sildik
        //IFlip flip;              çünkü zaten bunların referansları StateMachine'de tutuluyor, aynı referansları
        //IHealth health;          farklı farklı yerlerde birkaç tane tutmanın anlamı yok
        //IAttacker attacker;
        [SerializeField] float moveSpeed=3f;
        [SerializeField] float chaseDistance;
        [SerializeField] float attackDistance;
        [SerializeField] float maxAttackTime = 2f;
        [SerializeField] Transform[] patrols;


        StateMachines _stateMachine;
        PlayerController _playerController;

        [SerializeField] GameObject score; 

       
        private void Awake()
        {
            //_mover = new MoverWithTranslate(this,moveSpeed);
            //_animation = new CharacterAnimation(GetComponent<Animator>());
            //_flip = new FlipWithTransform(GetComponent<Transform>());
            _stateMachine = new StateMachines();
            _playerController = FindAnyObjectByType<PlayerController>().GetComponent<PlayerController>();
            //_health = GetComponent<IHealth>();
            //_attacker = GetComponent<Attacker>();
            //_health.OnHealthChanged += HandleHealthChange;
        }


        private IEnumerator Start()
        {
            IMover mover = new MoverWithTranslate(this, moveSpeed);
            IMyAnimation animation = new CharacterAnimation(GetComponent<Animator>());
            IFlip flip = new FlipWithTransform(GetComponent<Transform>());
            IHealth health = GetComponent<IHealth>();
            IAttacker attacker = GetComponent<Attacker>();
            IStopAtEdge stopAtEdge = GetComponent<StopAtEdge>();

            Idle idle = new Idle(mover,animation);
            Walk walk = new Walk(this,mover,animation,flip,patrols);
            ChasePlayer chasePlayer = new ChasePlayer(IsPlayerRightSide,stopAtEdge,mover,flip,animation);
            Attack attack = new Attack(this,_playerController,animation,attacker,maxAttackTime);
            TakeHit takeHit = new TakeHit(health,animation);
            //TakeHit takeHit = new TakeHit(animation);
            Dead dead = new Dead(animation,this,()=> Instantiate(score,transform.position,Quaternion.identity));

            //durumlar
            _stateMachine.AddTransition(idle, walk, () => !idle.IsIdle);
            _stateMachine.AddTransition(idle, chasePlayer, () => MeToPlayerDistance() < chaseDistance);
            _stateMachine.AddTransition(walk, chasePlayer, () => MeToPlayerDistance() < chaseDistance);
            _stateMachine.AddTransition(chasePlayer, attack, () => MeToPlayerDistance() < attackDistance);

            _stateMachine.AddTransition(walk, idle, () => !walk.isWalk);
            _stateMachine.AddTransition(chasePlayer, idle, () => MeToPlayerDistance() > chaseDistance);
            //_stateMachine.AddTransition(chasePlayer, walk, () => MeToPlayerDistance() > chaseDistance);
            _stateMachine.AddTransition(attack, chasePlayer, () => MeToPlayerDistance() > attackDistance);

            _stateMachine.SetState(idle);  //en başta tüm durumlar(7durum) burada _stateMAchine listesinin içine veriliyor, ilk durum idle olarak veriliyor

            _stateMachine.AddAnyState(dead, () => health.IsDead);
            _stateMachine.AddAnyState(takeHit, () => takeHit.IsTakeHit);
            //_stateMachine.AddAnyState(chasePlayer, () => !isTakeHit);

            _stateMachine.AddTransition(takeHit, chasePlayer, ()=> takeHit.IsTakeHit==false);
            yield return null;
        }
        /*private void OnEnable()
        {
            _health.OnHealthChanged += HandleHealthChange;
        }*/

        private void Update()
        {
            _stateMachine.Tick();
        }


        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }

        /*private void HandleHealthChange()
        {
            //isTakeHit = true;
        }*/
        private bool IsPlayerRightSide()
        {
           Vector2 result =  _playerController.transform.position- this.transform.position;

            if(result.x > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private float MeToPlayerDistance()
        {
            return Vector2.Distance(transform.position, _playerController.transform.position);
        }
    }

}
