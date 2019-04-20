using UnityEngine;
using UnityEngine.UI;


public class UISliderScript : MonoBehaviour
{
    public Slider slider;
    private PlayerMoverV2 mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = FindObjectOfType<PlayerMoverV2>();
        slider.maxValue = mover.marbleData.maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = mover.power;
    }
}