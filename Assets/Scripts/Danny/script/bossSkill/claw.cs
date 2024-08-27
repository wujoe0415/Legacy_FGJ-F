using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : BossBasicSkill
{
    public SpriteRenderer ClawPrefab;
    public SpriteRenderer ClawEffect;
    private bool _faceRight;

    private void Start()
    {
        _faceRight = ClawPrefab.flipX;
    }

    public override void UseSkill()
    {
        bool isRight = false;
        ClawPrefab.gameObject.SetActive(true);
        if (EnemyManager.Instance.Target != null)
            isRight = transform.position.x > EnemyManager.Instance.Target.transform.position.x;
        ClawPrefab.flipX = isRight ? _faceRight : !_faceRight;
        ClawEffect.flipX = isRight ? _faceRight : !_faceRight;
        ClawEffect.gameObject.SetActive(true);
        StartCoroutine(DisplayClaw());
    }
    private IEnumerator DisplayClaw()
    {
        yield return new WaitForSeconds(1f);
        ClawPrefab.gameObject.SetActive(false);
        ClawEffect.gameObject.SetActive(false);
    }
}