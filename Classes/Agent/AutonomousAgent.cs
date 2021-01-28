using UnityEngine;
using Unity.MLAgents;

public class AutonomousAgent : Agent
{
    private VehicleUserControl vehicleUserControl;

    private Vector3 agentLocalPosition;
    private Quaternion agentLocalRotation;

    public override void Initialize()
    {
        vehicleUserControl = GetComponent<VehicleUserControl>();
        agentLocalPosition = transform.localPosition;
        agentLocalPosition = transform.localEulerAngles;
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = agentLocalPosition;
        transform.localRotation = agentLocalRotation;


    }

    public override void OnActionReceived(float[] vectorAction)
    {
        vehicleUserControl.Steer(vectorAction[0]);
        vehicleUserControl.Throttle(vectorAction[1]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        actionsOut[1] = Input.GetAxis("Vertical");
    }
}
