using UnityEngine;

public class GoalScore : MonoBehaviour
{
    private AutonomousAgent smartDriver;


    private void Awake()
    {
        smartDriver = GameObject.FindWithTag("Agent").GetComponent<AutonomousAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!smartDriver)
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            smartDriver.GoalReward();
            Debug.Log("GoalScored");
        }
    }
}
