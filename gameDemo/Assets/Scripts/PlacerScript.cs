using System;
using UnityEngine;

public class PlacerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placeableObjectPrefabs;

    private GameObject currentPlaceableObject;
    private Grid grid;

    private int currentPrefabIndex = -1;

    private void Awake()                              //loads once every runtime
    {
        grid = FindObjectOfType<Grid>();              //set grid (only one exists)
    }
    
    private void Update()                             //runs every frame
    {
        HotkeyHandler();                              //checks hotkey and attaches schematic
        if (currentPlaceableObject != null)           //only run if holding a schematic
        {
            MoveCurrentObjectToMouse();               //place schematic
            ReleaseIfClicked();                       //remove schematic when done
        }
    }

    private void HotkeyHandler()
    {
        for (int i = 0; i < placeableObjectPrefabs.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + 1 + i))
            {
                if (PressedKeyOfCurrentPrefab(i))
                {
                    Destroy(currentPlaceableObject);
                    currentPrefabIndex = -1;
                }
                else
                {
                    if (currentPlaceableObject != null)
                    {
                        Destroy(currentPlaceableObject);
                    }

                    currentPlaceableObject = Instantiate(placeableObjectPrefabs[i]);
                    currentPrefabIndex = i;
                }

                break;
            }
        }
    }

    private bool PressedKeyOfCurrentPrefab(int i)
    {
        return currentPlaceableObject != null && currentPrefabIndex == i;
    }

    private void MoveCurrentObjectToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            currentPlaceableObject.transform.position = grid.GetNearestPointOnGrid(hitInfo.point);
            currentPlaceableObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
    }

    private void ReleaseIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentPlaceableObject = null;
        }
    }
}
