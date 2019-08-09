using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    public Transform grabCenter;
    public float grabRadius = 2;

    public Transform pickupAnchor;

    public void Grab()
    {
        var cols = Physics.OverlapSphere(grabCenter.position, grabRadius, 1 << LayerMask.NameToLayer("Pickable");

        cols[0].transform.SetParent(pickupAnchor);
        cols[0].transform.localPosition = Vector3.zero;
        cols[0].transform.localRotation = Quaternion.identity;
    }
}
