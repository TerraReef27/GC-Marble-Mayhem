using UnityEngine;
using UnityEngine.UI;


public class UISliderScript : MonoBehaviour
{
    public Slider slider;
    private PlayerMover mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = FindObjectOfType<PlayerMover>();
        slider.maxValue = mover.maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = mover.power;
    }
}
