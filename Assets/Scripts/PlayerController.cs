using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public int maxLife;
    public Slider slider;
    EnemyController enemycontroller;
    DataController dataController;

    [HideInInspector]
    public int life;
    [HideInInspector]
    public bool dead;

    void Start()
    {
        enemycontroller = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        dataController = FindObjectOfType<DataController>();
        maxLife = dataController.allRoundData[dataController.RoundNum].PlayerHP;
        life = maxLife;
        slider = GetComponentInChildren<Slider>();
        if (slider)
        {
            
            slider.value = life;
        }
        anim = GetComponent<Animator>();
        dead = false;
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        
    }

    public void Hurt(int damage)
    {
        if (!dead)
        {
            life -= damage;
            anim.SetTrigger("Hurt");
            if (slider) slider.value = life;
        }
        if (life <= 0) Die();
    }

    public void Die()
    {
        dead = true;
        anim.SetBool("Die", true);
        if (slider) slider.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
