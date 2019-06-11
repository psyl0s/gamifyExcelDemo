using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    //[SerializeField]
    private float size = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int posX = Mathf.RoundToInt(position.x / size);
        int posY = Mathf.RoundToInt(position.y / size);
        int posZ = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)posX * size,
            (float)posY * size,
            (float)posZ * size);

        return result;
    }

    //grid point highlight
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(float x = 0; x < 40; x += size)
        {
            for(float z = 0; z < 40; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, .1f);
            }
        }
    }
}
