using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(StateController controller)//we need the parameter because we receive the info from the Scene Object from parameter.
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(StateController controller)//the state order to do the actions
    {
        for (var i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (var i = 0; i < transitions.Length; i++)
        {
            var decisionSucceeded = transitions[i].decision.Decide(controller);
            var targetState = (decisionSucceeded) ? transitions[i].trueState : transitions[i].falseState;

            controller.TransitionToState(targetState);
        }
    }
}