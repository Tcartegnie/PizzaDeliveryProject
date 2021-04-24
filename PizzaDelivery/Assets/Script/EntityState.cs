using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityState : MonoBehaviour
{
    public int PVmax;
    public int ActualPV;
    // Start is called before the first frame update
    void Start()
    {
        ActualPV = PVmax;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
