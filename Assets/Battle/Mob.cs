using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    float prihp;

    public float hp {
        get { return prihp; }
        set { whenMobGetInjured(); prihp += value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void whenMobGetInjured()
    {

    }
}
