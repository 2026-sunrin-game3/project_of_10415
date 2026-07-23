using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill1UI : MonoBehaviour
{
    [SerializeField] PlayerBattle battle;
    [SerializeField] Image skillIcon;
    [SerializeField] TextMeshProUGUI cooldownText;

    [SerializeField] Color activeColor = new Color(1f, 0.6f, 0f);      // 사용 중 주황
    [SerializeField] Color cooldownColor = Color.white;                 // 쿨타임 흰색
    [SerializeField] Color iconBrightColor = Color.white;               // 평소/사용중 아이콘 밝기
    [SerializeField] Color iconDarkColor = new Color(0.35f, 0.35f, 0.35f); // 쿨타임 중 아이콘 어둡게

    enum State { Idle, Active, Cooldown }
    State state = State.Idle;

    void Update()
    {
        float cool = battle.skill1Cool;
        float coolTime = battle.skill1CoolTime;
        float duration = battle.skill1Duration;

        // 남은 쿨타임으로 "사용 중"인지 "쿨타임 대기 중"인지 구분
        // cool 값이 (coolTime - duration)보다 크면 아직 버프 지속시간 내부라고 판단
        float remainAfterCool = coolTime - duration;

        if (cool <= 0)
        {
            SetState(State.Idle);
        }
        else if (cool > remainAfterCool)
        {
            SetState(State.Active);
            float remain = cool - remainAfterCool;
            cooldownText.text = remain.ToString("F1");
        }
        else
        {
            SetState(State.Cooldown);
            cooldownText.text = cool.ToString("F1");
        }
    }

    void SetState(State newState)
    {
        if (state == newState)
            return;

        state = newState;

        switch (state)
        {
            case State.Idle:
                cooldownText.gameObject.SetActive(false);
                skillIcon.color = iconBrightColor;
                break;
            case State.Active:
                cooldownText.gameObject.SetActive(true);
                cooldownText.color = activeColor;
                skillIcon.color = activeColor;
                break;
            case State.Cooldown:
                cooldownText.gameObject.SetActive(true);
                cooldownText.color = cooldownColor;
                skillIcon.color = iconDarkColor;
                break;
        }
    }
}