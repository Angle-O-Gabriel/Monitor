using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] public float PosX;
    [SerializeField] public float PosY;
    [SerializeField] public float PosZ = 0;
    [SerializeField] public GameObject Player;

    public void MovePos()
    {
        this.Player.transform.position = new Vector3(PosX, PosY, PosZ);
    }

}
