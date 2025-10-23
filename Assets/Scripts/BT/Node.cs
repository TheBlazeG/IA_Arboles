using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class Node 
    {
        public enum status
        {
           Success,
           Failure,
           Running
        }

        public readonly string name;
        public readonly List<Node> children = new List<Node>();

        protected int currentChild= 0;

        public Node(string name)
        {
            this.name = name;
        }

        public void SetstoXD(Node child)
        {
            children.Add(child);
        }

        public virtual status Process() => children[currentChild].Process();

        public virtual void Reset()
        {
            currentChild = 0;
            foreach (Node child in children)
            {
                                           child.Reset();
            }
        }
    }

    public class Leaf : Node
    {
        readonly IStrategy strategy;

        public Leaf(string name, IStrategy strategy) : base(name)
        {
            this.strategy = strategy;
        }

        public override status Process() => strategy.Process();

        public override void Reset() => strategy.Reset();
    }

    public class BehaviourTree : Node
    {
        public BehaviourTree(string name) : base(name){}

        public override status Process()
        {
            while (currentChild < children.Count)
            {
                var status = children[currentChild].Process();
                if (status != status.Success)
                {
                    return status;
                }

                currentChild++;
            }

            return status.Success;
        }
    }
}

