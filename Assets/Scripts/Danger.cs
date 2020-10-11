using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Danger : MonoBehaviour
{
    [SerializeField] private Transform _rock;
    [SerializeField] private float myGravityScale = 1; 

    private bool flag = true;

    //when player enter the zone, rock shakes
    public void EnterMethodShake()
    {
        _rock.DOShakeRotation(1f, 10, 30, 55).SetEase(Ease.InBounce);
        flag = false;
    }

    //when player enter the zone, rock falls
    public void EnterMethodFall()
    {
        _rock.GetComponent<Rigidbody2D>().gravityScale = myGravityScale;
        flag = false;
    }

    //when player enter the zone, rock shakes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enter the zone, rock shakes;
        if (this.gameObject.tag == "RockShake" && flag && collision.tag == "Player")
        {
            EnterMethodShake();
        }

        //leave the zone, rock falls;
        if (this.gameObject.tag == "RockFall" && flag && collision.tag == "Player")
        {
            EnterMethodFall();
        }

    }

}
