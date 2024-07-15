using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;


public class AIBehaviour : MonoBehaviour
{
    [SerializeField] public float RoamRate = 1;
    [SerializeField] public int SwitchRate = 2;
    [SerializeField] public Points[] Routes;

    private int RouteMarker;
    public int CurrentRoute;
    private bool RoundStart;
    private int MoveWhere;

    // Start is called before the first frame update
    void Start()
    {
        CurrentRoute = Random.Range(0, Routes.Length);
        RouteMarker = Random.Range(0, Routes[CurrentRoute].GetSize());
        RoundStart = true;

        InvokeRepeating("MoveKiller", 0.0f, RoamRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveKiller()
    {
        if(RoundStart)
        {
            if (Random.Range(0, 2) == 0)
            {
                MoveWhere = -1;
                RoundStart = false;
            }
            else
            {
                MoveWhere = 1;
                RoundStart = false;
            }

        }

        this.transform.position = Routes[CurrentRoute].GetMarker(RouteMarker);

        RouteMarker += MoveWhere;

        if(RouteMarker < 0)
        {
            if(Routes[CurrentRoute].IsThisRepeatable() == true)
            {
                RouteMarker = Routes[CurrentRoute].GetSize() - 1;
            }
            else
            {
                MoveWhere = -MoveWhere;
                RouteMarker += MoveWhere;
            }

            
        }

        if(RouteMarker == Routes[CurrentRoute].GetSize())
        {
            if (Routes[CurrentRoute].IsThisRepeatable() == true)
            {
                RouteMarker = 0;
            }
            else
            {
                MoveWhere = -MoveWhere;
                RouteMarker += MoveWhere;
            }
        }

        CheckSwitch();

    }

    private void CheckSwitch()
    {
        for(int i = 0; i < Routes.Length; i++)
        {
            if(i != CurrentRoute)
            {
                for(int j = 0; j < Routes[i].GetSize(); j++)
                {
                    if (Routes[i].GetMarker(j) == Routes[CurrentRoute].GetMarker(RouteMarker))
                    {
                        if(Random.Range(0, SwitchRate) == 1)
                        {
                            CurrentRoute = i;
                            RouteMarker = j;
                            RoundStart = true;
                        }
                    }
                }
            }
        }
    }

}
