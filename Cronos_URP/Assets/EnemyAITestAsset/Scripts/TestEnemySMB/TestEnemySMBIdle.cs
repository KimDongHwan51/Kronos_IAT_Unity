using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemySMBIdle : SceneLinkedSMB<TestEnemyBehavior>
{
    public float minimumIdleGruntTime = 2.0f;
    public float maximumIdleGruntTime = 5.0f;

    public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (minimumIdleGruntTime > maximumIdleGruntTime)
            minimumIdleGruntTime = maximumIdleGruntTime;

    }

    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnSLStateNoTransitionUpdate(animator, stateInfo, layerIndex);

        _monoBehaviour.FindTarget();
        if (_monoBehaviour.target != null)
        {
            _monoBehaviour.StartPursuit();
        }
    }
}