using UnityEngine;

public class CameraController : MonoBehaviour
{

    public PlayerController player;
    public Camera me;
    public float followDistance;
    public float verticalBuffer;
    public float horizontalBuffer;
    public float smoothTime;

    private GameObject car;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {

    }

    void LateUpdate()
    {
        Vector3 targetPosition = car.transform.TransformPoint(new Vector3(horizontalBuffer, verticalBuffer, -followDistance));
        //transform.position = car.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.eulerAngles = new Vector3(30, car.transform.eulerAngles.y, 0);
    }

    public void setPlayer(int p)
    {
        car = player.carObjects[p];
    }

    public void setUICull(bool yeah)
    {
        if (yeah)
        {
            me.cullingMask = 32;
            Debug.Log(me.cullingMask.ToString());
        }
        else
        {
            me.cullingMask = LayerMask.NameToLayer("Everything");
        }
    }
}
