using System;
using UnityEngine;
using UnityEngine.UI;

public class damageIndicator : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] float time, floatingScale;

    public static damageIndicator Instance = null;
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        time += Time.deltaTime;

        transform.Translate(Vector2.up * floatingScale * Time.deltaTime);

        if (time > 2f)
        {
            Destroy(gameObject);
        }
    }

    public void IndicateDamage(float damage, Vector2 pos, Color color)
    {
        damageIndicator indicator = Instantiate(this, pos, Quaternion.identity);
        indicator.text.text = Mathf.Round(damage).ToString();
        indicator.text.color = color;
    }
}
