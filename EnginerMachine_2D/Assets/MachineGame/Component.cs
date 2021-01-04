using UnityEngine;

public abstract class Component : MonoBehaviour
{
    private bool active = false;
    public bool Active{
        get{ 
            return active; 
        }

        set{
            if (active != value)
                if (!active)
                    OnActive();
                else
                    OnDesactive();
            active = value;
        }
    }

    protected abstract void OnActive();
    protected abstract void OnDesactive();

}