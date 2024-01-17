using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.StatesMachines
{
    public class StateMachines
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>(); //list yap�m�zda durumlar�m�z� tutaca��z (EnemyControllerdan gelen 7 durum var)
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();



        IState _currentState;

        public void SetState(IState state)// 7)ge�i� yapaca�� animasyon buraya verilir
        {
            if (_currentState == state) return;

            _currentState?.OnExit();  //�uanki animasyondan ��k
            _currentState = state;    //gelen animasyonu �uanki animasyona e�itle
            _currentState.OnEnter();  //yeni animasyona gir
        }
        public void Tick()// bu EnemyController i�inde Update'de �al���yor
        {
            StateTransition stateTransition = CheckForTransition(); // 5) 7 durumdan biri gelir
            if (stateTransition != null)  //stateTransition bo� de�ilse bir de�i�im olmu�
            {
                SetState(stateTransition.To); //6)ge�i� yapaca�� animasyona ge�ilir
            }

            _currentState.Tick(); //8)bir de�i�im olmam��sa halihaz�rdaki ani�masyon �al��maya devam eder, bu tick animasyon(IState'den miras alan) scriptlerinin i�indeki Tick
        }



        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;

            }
            foreach (StateTransition stateTransition in _stateTransitions)//2)AddTransition metodundan _stateTransitions listesine giren de�erler var, bu her bi de�er i�in(7-8durum i�in)
            {
                if (stateTransition.Condition() && stateTransition.From == _currentState) //3)durum sa�lan�yorsa ve ba�lang��taki durumla �uanki durum e�it ise bana bu durumu d�n
                {
                    return stateTransition; //4)listenin i�indeki 7-8 durumdan biri sa�lan�r ve onu d�ner, sa�lanmazsa bo� d�ner
                }

            }
            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)//1)buraya EnemyControllerdan 7 -8 tane durum ekleniyor
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(stateTransition); //kimden kime nas�l gidice�i de�erini tutuyoruz

        }
        public void AddAnyState(IState to,System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null,to, condition);
            _anyStateTransitions.Add(anyStateTransition);
        }
    }

    /*EnemyController'dan gelen 7 durum listeye eklendi AddTransition Metodu sayesinde. CheckForTransition Methodunda durum sa�lan�yorsa ve ba�lang��taki(From'daki) durumla �uanki durum e�it ise bana bu durumu d�n,d�n�len durum Tick metodunda stateTransitionun i�ine verilecek ve SetState'de �al��t�r�l�p _currentState'den ��k�lacak, yeni animasyona ge�ilecek.
     */

}
