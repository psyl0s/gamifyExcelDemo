using UnityEngine;

public class CameraControllerSelf : MonoBehaviour
{
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector3 panLim;
    public float scrollSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
            pos.x -= panSpeed * Time.deltaTime;
        }

        //scroll to zoom. (taken out, maybe replace with - and + ?
        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //pos.y -= scroll * 100f * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLim.x, panLim.x+1);
        //pos.y = Mathf.Clamp(pos.y, 10, panLim.y);
        pos.z = Mathf.Clamp(pos.z, -panLim.z, panLim.z+1);

        transform.position = pos;

        
    }
}
