using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilMovement : MonoBehaviour
{
    [SerializeField]
    Transform target;

    float speed = 4.2f;
    float Soulspeed = 1f;

    List<GameObject> sacrificeposition = new List<GameObject>();

    Animator animator;


    private static DevilMovement singleton;

    private void Awake()
    {
        singleton = this;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    float LastDistance = 10000f;
    bool flowSoul = false;
    private void follow()
    {
        //Folge dem Spieler wenn keine Seelen vorhanden sind.
        if (sacrificeposition.Count == 0)
        {
            float direction = target.position.x - transform.position.x;
            animator.SetFloat("direction", direction);


            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, 0), speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Angry", true);
            //Gehe in Die Richtung der ersten Seele
            float currendDistance = Vector2.Distance(transform.position, new Vector2(sacrificeposition[0].transform.position.x, transform.position.y));
            if (currendDistance > 1.5f && LastDistance > currendDistance && !flowSoul)
            {
                LastDistance = currendDistance;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(sacrificeposition[0].transform.position.x, 0), speed * Time.deltaTime);
                
                
            }
            else
            {
                flowSoul = true;
                animator.SetBool("getSoul",flowSoul);
                //Lass die Seele zu mir schweben
                if (Vector2.Distance(transform.position, sacrificeposition[0].transform.position) > 1.5f)
                {
                    sacrificeposition[0].transform.position = Vector2.MoveTowards(sacrificeposition[0].transform.position,transform.position, Soulspeed * Time.deltaTime);
                }
                else
                {
                    GameObject tmp = sacrificeposition[0];
                    sacrificeposition.Remove(tmp);
                    Destroy(tmp);
                    flowSoul = false;
                    animator.SetBool("getSoul", flowSoul);
                    animator.SetBool("Angry", false);
                    LastDistance = 10000f;
                }
            }
        }
    }


    public static void addSacrificePos(GameObject newPos)
    {
        if (singleton.sacrificeposition.Count == 0)
            singleton.LastDistance = 10000f;
        singleton.sacrificeposition.Add(newPos);
        
    }

}
