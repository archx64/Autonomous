using UnityEngine;
using Unity.MLAgents;

[RequireComponent(typeof(VehicleController))]
public class AutonomousAgent : Agent
{
    private VehicleUserControl vehicleUserControl;

    private Vector3 agentLocalPosition;
    private Quaternion agentLocalRotation;
    private Rigidbody rb;

    //public GameObject[] traffic;
    //private Vector3[] trafficLocations;
    //private Quaternion[] trafficRotations;
    //private Rigidbody[] trafficRigidbodies;

    public override void Initialize()
    {
        //InitializeTraffic();

        rb = GetComponent<Rigidbody>();
        vehicleUserControl = GetComponent<VehicleUserControl>();
        agentLocalPosition = transform.localPosition;
        agentLocalRotation = transform.localRotation;
    }

    public override void OnEpisodeBegin()
    {
        //ResetTraffic();

        vehicleUserControl.Steer(0);
        vehicleUserControl.Throttle(0);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.localPosition = agentLocalPosition;
        transform.localRotation = agentLocalRotation;
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        vehicleUserControl.Steer(vectorAction[0]);
        vehicleUserControl.Throttle(vectorAction[1]);

        AddReward(vectorAction[1] * 0.01f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.5f)
        {
            EndEpisode();
            SetReward(-0.1f);
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = Input.GetAxis("Horizontal");
        actionsOut[1] = Input.GetAxis("Vertical");
    }

    public void GoalReward()
    {
        AddReward(0.1f);
    }

    //private void InitializeTraffic()
    //{
    //    trafficLocations = new Vector3[traffic.Length];
    //    trafficRotations = new Quaternion[traffic.Length];
    //    trafficRigidbodies = new Rigidbody[traffic.Length];

    //    for (int i = 0; i < traffic.Length; i++)
    //    {
    //        trafficRigidbodies[i] = traffic[i].GetComponent<Rigidbody>();
    //        trafficLocations[i] = traffic[i].transform.localPosition;
    //        trafficRotations[i] = traffic[i].transform.localRotation;
    //    }
    //}


    //private void ResetTraffic()
    //{
    //    for (int i = 0; i < traffic.Length; i++)
    //    {
    //        trafficRigidbodies[i].velocity = Vector3.zero;
    //        trafficRigidbodies[i].angularVelocity = Vector3.zero;

    //        traffic[i].transform.localPosition = trafficLocations[i];
    //        traffic[i].transform.localRotation = trafficRotations[i];
    //    }
    //}
}
