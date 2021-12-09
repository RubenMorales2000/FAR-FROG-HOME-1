using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cityLife : MonoBehaviour
{
    private bool hasGenerated;
    void Start()
    {
        this.hasGenerated = false;
    }

    public void setHasGenerated()
    {
        this.hasGenerated = true;
    }

    public bool getHasGenerated()
    {
        return this.hasGenerated;
    }
}
