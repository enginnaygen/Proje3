using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.StatesMachines
{
    public class StateTransition
    {
        IState _from;
        IState _to;
        public System.Func<bool> _condition;

        public IState To => _to;
        public IState From => _from;
        public System.Func<bool> Condition => _condition;

        public StateTransition(IState from, IState to, System.Func<bool> condition)//nereden(from) nereye(to) hangi durumda(condition) ge�ece�i ayarlan�yor her newlenme i�leminde

        {
            _from = from;
            _to = to;
            _condition = condition;
        }
    }

}
