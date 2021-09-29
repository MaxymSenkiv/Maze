using UnityEngine;
using UnityEngine.UI;

public class DefaultDifficulty : MonoBehaviour
{
    [SerializeField] private MazeSpawner MazeSpawner;

    void Start()
    {
        var slider = this.GetComponent<Slider>();

        if (MazeSpawner._height >= 3)
        {
            slider.value = MazeSpawner._height;
        }  
    }
}
