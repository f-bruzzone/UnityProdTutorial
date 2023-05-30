using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    // Loading gamescene creates subscribers that will persist every time the game
    // scene is loaded because these counters have static events. This will reset 
    // their subscribers so they don't grow indefinitely.
    private void Awake()
    {
        CuttingCounter.ResetStaticdata();
        BaseCounter.ResetStaticdata();
        TrashCounter.ResetStaticdata();
    }
}
