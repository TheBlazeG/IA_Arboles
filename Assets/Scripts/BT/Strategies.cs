using UnityEngine;

namespace BehaviourTree
{
 
    public interface IStrategy
    {
        Node.status Process();
        void Reset();
    }   
}
