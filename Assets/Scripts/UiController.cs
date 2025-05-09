using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TMP_Text healthText;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        UpdateHealthSlider();
    }

    public void UpdateHealthSlider()
    {
        healthSlider.maxValue = PlayerController.Instance.maxHealth;
        healthSlider.value = PlayerController.Instance.health;

        healthText.text = $"{PlayerController.Instance.health}/{PlayerController.Instance.maxHealth}";
    }
}
