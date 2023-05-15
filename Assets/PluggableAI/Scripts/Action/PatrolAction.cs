using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.navMeshAgent.destination = controller.wayPointList[controller.nextWayPoint].position;

        //controller.navMeshAgent.Resume(); deprecated
        controller.navMeshAgent.isStopped = false;

        if (controller.navMeshAgent.remainingDistance > controller.navMeshAgent.stoppingDistance)
        {
            return;
        }

        if (controller.navMeshAgent.pathPending)
        {
            return;
        }

        //we have arrived our destination
        controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
    }
}