using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Assets.Core.StateStack
{
    public class StateStack
    {
        Stack<State> mStack;

        public StateStack()
        {
            mStack = new Stack<State>();
        }

        public void Push(State newState)
        {
            if (newState == null)
            {
                Debug.Log("Pushed Null into Stack");
                return;
            }

            newState.OnPushed();
            if (mStack.Count > 0)
            {
                mStack.Peek().OnPressed();
            }
            mStack.Push(newState);
        }
        public State Pop()
        {
            State popedState = null;
            if (mStack.Count > 0)
            {
                mStack.Peek().OnPoped();
                popedState = mStack.Pop();
            }
            if (mStack.Count > 0)
            {
                mStack.Peek().OnReturnToTop();
            }
            return popedState;
        }

        public State Peek()
        {
            if (mStack.Count > 0)
            {
                return mStack.Peek();
            }
            else
            {
                return null;
            }
        }
    }
}