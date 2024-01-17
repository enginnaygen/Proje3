using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.StatesMachines
{
    public class StateMachines
    {
        List<StateTransition> _stateTransitions = new List<StateTransition>(); //list yapýmýzda durumlarýmýzý tutacaðýz (EnemyControllerdan gelen 7 durum var)
        List<StateTransition> _anyStateTransitions = new List<StateTransition>();



        IState _currentState;

        public void SetState(IState state)// 7)geçiþ yapacaðý animasyon buraya verilir
        {
            if (_currentState == state) return;

            _currentState?.OnExit();  //þuanki animasyondan çýk
            _currentState = state;    //gelen animasyonu þuanki animasyona eþitle
            _currentState.OnEnter();  //yeni animasyona gir
        }
        public void Tick()// bu EnemyController içinde Update'de çalýþýyor
        {
            StateTransition stateTransition = CheckForTransition(); // 5) 7 durumdan biri gelir
            if (stateTransition != null)  //stateTransition boþ deðilse bir deðiþim olmuþ
            {
                SetState(stateTransition.To); //6)geçiþ yapacaðý animasyona geçilir
            }

            _currentState.Tick(); //8)bir deðiþim olmamýþsa halihazýrdaki aniþmasyon çalýþmaya devam eder, bu tick animasyon(IState'den miras alan) scriptlerinin içindeki Tick
        }



        private StateTransition CheckForTransition()
        {
            foreach (StateTransition anyStateTransition in _anyStateTransitions)
            {
                if (anyStateTransition.Condition.Invoke()) return anyStateTransition;

            }
            foreach (StateTransition stateTransition in _stateTransitions)//2)AddTransition metodundan _stateTransitions listesine giren deðerler var, bu her bi deðer için(7-8durum için)
            {
                if (stateTransition.Condition() && stateTransition.From == _currentState) //3)durum saðlanýyorsa ve baþlangýçtaki durumla þuanki durum eþit ise bana bu durumu dön
                {
                    return stateTransition; //4)listenin içindeki 7-8 durumdan biri saðlanýr ve onu döner, saðlanmazsa boþ döner
                }

            }
            return null;
        }

        public void AddTransition(IState from, IState to, System.Func<bool> condition)//1)buraya EnemyControllerdan 7 -8 tane durum ekleniyor
        {
            StateTransition stateTransition = new StateTransition(from, to, condition);
            _stateTransitions.Add(stateTransition); //kimden kime nasýl gidiceði deðerini tutuyoruz

        }
        public void AddAnyState(IState to,System.Func<bool> condition)
        {
            StateTransition anyStateTransition = new StateTransition(null,to, condition);
            _anyStateTransitions.Add(anyStateTransition);
        }
    }

    /*EnemyController'dan gelen 7 durum listeye eklendi AddTransition Metodu sayesinde. CheckForTransition Methodunda durum saðlanýyorsa ve baþlangýçtaki(From'daki) durumla þuanki durum eþit ise bana bu durumu dön,dönülen durum Tick metodunda stateTransitionun içine verilecek ve SetState'de çalýþtýrýlýp _currentState'den çýkýlacak, yeni animasyona geçilecek.
     */

}
