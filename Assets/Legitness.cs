using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class Legitness : MonoBehaviour
{
    //Inputed Stuff
    public UnityEngine.UI.Dropdown type;
    public UnityEngine.UI.InputField pokenumber;
    public UnityEngine.UI.InputField candynumber;
    //Text at bottom
    public UnityEngine.UI.Text math;
    public UnityEngine.UI.Text egg;
    //Basic info
    public int types;
    public int pokesnumber;
    public int candysnumber;
    //Calculated Stuff
    public float time;
    public float xp;
    public float alltime;
    public float allxp;
    public virtual void Add()
    {
        this.xp = 0;
        this.time = 0;
        this.pokesnumber = int.Parse(this.pokenumber.text);
        this.candysnumber = int.Parse(this.candynumber.text);
        this.Require();
        Debug.Log(this.types);
        while ((this.candysnumber > (this.types - 1)) && (this.pokesnumber != 0))
        {
            this.pokesnumber--;
            this.candysnumber = this.candysnumber - this.types;
            this.time = this.time + 0.5f;
            this.xp = this.xp + 1000;
            this.alltime = this.alltime + 0.5f;
            this.allxp = this.allxp + 1000;
        }
        while (this.pokesnumber > (this.types - 1))
        {
            this.pokesnumber = this.pokesnumber - this.types;
            this.time = this.time + 0.5f;
            this.xp = this.xp + 1000;
            this.alltime = this.alltime + 0.5f;
            this.allxp = this.allxp + 1000;
        }
        this.math.text = ((((((((("For that last entry, you will have " + this.pokesnumber) + " extra pokemon left over, ") + this.candysnumber) + " candy left over, before you evolve all of these pokemon you should transfer the ") + this.pokesnumber) + " extra pokemon to get the maximum candy, if you do you will gain ") + this.xp) + " XP, and the estimated time to evolve all of these pokemon is ") + this.time) + " minutes.";
    }

    public virtual void Calculate()
    {
        this.Eggs();
        this.math.text = ((("Overall xp gained: " + this.allxp) + ". Time it will take: ") + this.alltime) + " mins. Don't forget to use a lucky egg!";
    }

    public virtual void Require()
    {
        if (this.type.value == 0)
        {
            this.types = 12;
        }
        else
        {
            if (this.type.value == 1)
            {
                this.types = 25;
            }
            else
            {
                if (this.type.value == 2)
                {
                    this.types = 50;
                }
                else
                {
                    if (this.type.value == 3)
                    {
                        this.types = 100;
                    }
                    else
                    {
                        if (this.type.value == 4)
                        {
                            this.types = 400;
                        }
                    }
                }
            }
        }
    }

    public virtual void Eggs()
    {
        if (this.alltime > 30)
        {
            this.egg.text = "Egg Recomendation: It would take you longer than 30 min to evolve all of these pokemon. You will need another egg.";
        }
        else
        {
            if (((((this.alltime == 25) || (this.time == 26)) || (this.time == 27)) || (this.time == 28)) || (this.time == 29))
            {
                this.egg.text = "Go ahead and use that egg! This is the max amount you can do without going over 30 min";
            }
            else
            {
                if (this.alltime == 30)
                {
                    this.egg.text = "You will have to be fast to make sure you dont miss any in 30 min";
                }
                else
                {
                    if (this.alltime < 25)
                    {
                        this.egg.text = "Wait until you have more pokemon to evolve";
                    }
                }
            }
        }
    }

}