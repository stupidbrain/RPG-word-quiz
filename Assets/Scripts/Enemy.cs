using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    //public GameObject rewardItem;
    public Slider slider;
    public int attackDamage = 10;
    private Animator anim;
    private int maxLife;
    [HideInInspector]
    public int life;
    private bool alive;
    public UnityEvent dieEvent;
    PlayerController playercontroller;
    DataController dataController;

    protected void start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        dataController = FindObjectOfType<DataController>();
        anim = GetComponent<Animator>();
        maxLife = dataController.allRoundData[dataController.RoundNum].EnemyHP;
        life = maxLife;
        
        slider = GetComponentInChildren<Slider>();
        if (slider)
        {
            slider.value = life;
            
        }
        alive = true;
    }

    public virtual void Attack()
    {
        anim.SetTrigger("EnemyAttack");
        
    }

    public virtual void HurtAnim()
    {
        anim.SetTrigger("EnemyHurt");
    }

    public virtual void Hurt(int damage)
    {
        if (alive)
        {
            life -= damage;
            if (slider) slider.value = life;
                        
        }
        if (life <= 0) Die();
    }

    public virtual void Die()
    {
        alive = false;
        anim.SetTrigger("Die");
        dieEvent.Invoke();
        //Instantiate(rewardItem, transform.position, Quaternion.identity);
        //if (slider) slider.transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    protected void update()
    {

    }
}
