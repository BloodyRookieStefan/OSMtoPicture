using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMtoPicture.lib.template
{
    internal class StateMachine_Template
    {

        private Dictionary<StateTransition, int> Transitions = new Dictionary<StateTransition, int>();  // Storage of transitions
        private bool InitDone = false;                                                                  // Flag if State Machine initialization is done
        private int CurrentState;                                                                       // Current State Machine state

        /// <summary>
        /// State Machine transition
        /// </summary>
        public class StateTransition
        {
            readonly int CurrentState;
            readonly int Command;

            public StateTransition(object currentState, object command)
            {
                CurrentState = (int)(currentState);
                Command = (int)(command);
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }
        }

        /// <summary>Get next state based on command</summary>
        /// <param name="command">PlayerCommand to send</param>
        /// <returns>Next state</returns>
        /// <exception cref="System.Exception">Invalid transition</exception>
        private int GetNext(int command)
        {
            StateTransition transition = new StateTransition(CurrentState, command);
            if (!Transitions.TryGetValue(transition, out int nextState))
                throw new System.Exception($"Invalid transition: {CurrentState} -> {command}");
            return nextState;
        }

        /// <summary>
        /// Add State Machine transition
        /// </summary>
        /// <param name="transition">Transition</param>
        /// <param name="targetState">State after transition</param>
        /// <exception cref="System.Exception">Invalid operation</exception>
        protected void AddTransition(StateTransition transition, object targetState)
        {
            // Was state machine already initiallized?
            if (InitDone)
                throw new System.Exception("Invalid operation. State Machine already inizialized");

            if (!Transitions.ContainsKey(transition))
                Transitions.Add(transition, (int)(targetState));
            else
                throw new System.Exception("Invalid operation. Transition already exists");
        }

        /// <summary>
        /// Start State Machine
        /// </summary>
        /// <param name="startState">Start state</param>
        protected void Initialize(object startState)
        {
            // Was state machine already initiallized?
            if (InitDone)
                throw new System.Exception("Invalid operation. State Machine already inizialized");

            CurrentState = (int)(startState);
            InitDone = true;
        }

        /// <summary>Get to next state</summary>
        /// <param name="command">PlayerCommand to send</param>
        /// <returns>New state</returns>
        protected int GoNext(object command)
        {
            CurrentState = GetNext((int)(command));
            return CurrentState;
        }

        /// <summary>
        /// Get current State Machine state
        /// </summary>
        /// <returns>State Machine value</returns>
        protected int GetState() { return CurrentState; }
    }
}
