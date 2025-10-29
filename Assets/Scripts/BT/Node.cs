using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTrees
{
    public class Sequence : Node
    {
        public Sequence(string name) : base(name)
        {
        }

        public override status Process()
        {
            if (currentChild<children.Count)
            {
                switch (children[currentChild].Process())
                {
                    case status.Running:
                        return status.Running;
                    case status.Failure:
                        Reset();
                        break;
                    default:
                        currentChild++;
                        return currentChild== children.Count ? status.Success : status.Running;
                }
            }
            Reset();
            return status.Success;
        }
    }

    public class Selector : Node
    {
        public Selector(string name) : base(name) { }

        public override status Process()
        {
            if (currentChild<children.Count)
            {
                switch (children[currentChild].Process())
                {
                    case status.Running:
                        return status.Running;
                    case status.Success:
                        Reset();
                        return status.Success;
                    default:
                        currentChild++;
                        return currentChild==children.Count ? status.Failure : status.Running;
                        
                }
            }
            return status.Failure;
        }
    }

    #region base
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
    #endregion
}

