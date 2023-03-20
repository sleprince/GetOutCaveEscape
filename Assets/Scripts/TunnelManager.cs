using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    public int tunnelNum;

    public static TunnelManager instance;
    public static TunnelManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
    }
}
