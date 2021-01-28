using UnityEngine;

[RequireComponent(typeof(VehicleController))]
public class VehicleUserControl : MonoBehaviour
{
    private VehicleController m_Car; // the car controller we want to use

    private float throttle;
    private float steer;

    public void Throttle(float value)
    {
        throttle = value;
    }

    public void Steer(float value)
    {
        steer = value;
    }

    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<VehicleController>();
    }

    private void FixedUpdate()
    {
        // pass the input to the car!

        m_Car.Move(steer, throttle, throttle, 0);

        //#if !MOBILE_INPUT
        //        float h = Input.GetAxis("Horizontal");
        //        float v = Input.GetAxis("Vertical");
        //        float handbrake = Input.GetAxis("Jump");
        //        m_Car.Move(h, v, v, handbrake);
        //#else
        //        m_Car.Move(h, v, v, );
        //#endif
    }


}

