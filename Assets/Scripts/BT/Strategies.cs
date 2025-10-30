using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BehaviourTrees
{

    public interface IStrategy
    {
        Node.status Process();

        void Reset()
        {
            //nada
        }
}

    public class Condition : IStrategy
    {
        private readonly Func<bool> predicate;

        public Condition(Func<bool> predicate)
        {
            this.predicate = predicate;
        }

        public Node.status Process() => predicate() ? Node.status.Success : Node.status.Failure;
    }

    public class ActionStrategy : IStrategy
    {
        private readonly Action doSomething;

        public ActionStrategy(Action doSomething)
        {
            this.doSomething = doSomething;
        }

        public Node.status Process()
        {
            doSomething();
            return Node.status.Success;
        }
    }

    public class PatrolStrategy : IStrategy
    {
        public Transform entity;
        public NavMeshAgent agent;
        public List<Transform>patrolPoints;
        public float patrolSpeed;
        public int currentIndex;

        private bool isPathCalculated;

        public PatrolStrategy(Transform entity, NavMeshAgent agent, List<Transform> patrolPoints, float patrolSpeed)
        {
            this.entity = entity;
            this.agent = agent;
            this.patrolPoints = patrolPoints;
            this.patrolSpeed = patrolSpeed;
        }

        public Node.status Process()
        {
            if (currentIndex == patrolPoints.Count)
            {
                return Node.status.Success;
            }

            var target = patrolPoints[currentIndex];
            agent.SetDestination(target.position);
            entity.LookAt(new Vector3(target.position.x,entity.position.y,target.position.z));

            if (isPathCalculated==true && agent.remainingDistance<.1f)
            {
                isPathCalculated = false;
                currentIndex++;
            }
            if (agent.pathPending==true)
            {
                isPathCalculated = true;
            }
            return Node.status.Running;
        }

        public void Reset()=>currentIndex = 0;


    }
}
