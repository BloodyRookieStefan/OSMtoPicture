using OSMtoPicture.lib.template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMtoPicture.lib
{
    /// <summary>
    /// Available program states
    /// </summary>
    public enum ProgramStates
    {
        Init,
        Idle,
        InvalidURL,
        Saving,
    }

    /// <summary>
    /// Available program transitions
    /// </summary>
    public enum ProgramTransition
    {
        SetInitDone,
        SetInvalidURL,
        SetIdle,
        SetSaving,
    }

    internal class StateMachine : StateMachine_Template
    {
        public StateMachine()
        {
            // State machine transitions
            AddTransition(new StateTransition(ProgramStates.Init, ProgramTransition.SetInitDone), ProgramStates.Idle);

            AddTransition(new StateTransition(ProgramStates.Idle, ProgramTransition.SetSaving), ProgramStates.Saving);
            AddTransition(new StateTransition(ProgramStates.Saving, ProgramTransition.SetIdle), ProgramStates.Idle);

            AddTransition(new StateTransition(ProgramStates.Idle, ProgramTransition.SetInvalidURL), ProgramStates.InvalidURL);
            AddTransition(new StateTransition(ProgramStates.InvalidURL, ProgramTransition.SetIdle), ProgramStates.Idle);

            // Start state
            Initialize(ProgramStates.Init);
        }

        /// <summary>
        /// Go to next state via transition command
        /// </summary>
        /// <param name="t">Transition command</param>
        public void GoToNextState(ProgramTransition t)
        {
            base.GoNext(t);
        }

        /// <summary>
        /// Get current state of state machine
        /// </summary>
        /// <returns>Current state</returns>
        public ProgramStates GetCurrentState()
        {
            return (ProgramStates)base.GetState();
        }
    }
}
