using Buttons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttons.Controllers
{
    public class ButtonController : Controller
    {
        //TODO add database for users and high score

        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        public ActionResult Index()
        {
            for(int i = 0; i < 25; i++)
			{
                if (random.Next(10) > 5)
                {
                    buttons.Add(new ButtonModel(true));
                }
				else
				{
                    buttons.Add(new ButtonModel(false));
				}
            }
            return View("Index", buttons);
        }

        public ActionResult HandleButtonClick(string mine)
        {
            int buttonNumber = Int32.Parse(mine);
            buttons[buttonNumber].State = !buttons[buttonNumber].State;

            if(buttonNumber + 1 < buttons.Count)
			{
                if(buttonNumber % 5 != 4)
				{

                    if (buttons[buttonNumber + 1].State == true)
                    {
                        buttons[buttonNumber + 1].State = !buttons[buttonNumber + 1].State;
                    }
			        else
			        {
                        buttons[buttonNumber + 1].State = buttons[buttonNumber + 1].State = true;
			        }
				}

            }

            if (buttonNumber - 1 >= 0)
            {
                if(buttonNumber % 5 != 0)
				{
                    if (buttons[buttonNumber - 1].State == true)
                    {
                        buttons[buttonNumber - 1].State = !buttons[buttonNumber - 1].State;
                    }
                    else
                    {
                        buttons[buttonNumber - 1].State = buttons[buttonNumber - 1].State = true;
                    }
				}

            }

            if (buttonNumber + 5 < buttons.Count)
            {
                if (buttons[buttonNumber + 5].State == true)
                {
                    buttons[buttonNumber + 5].State = !buttons[buttonNumber + 5].State;
                }
                else
                {
                    buttons[buttonNumber + 5].State = buttons[buttonNumber + 5].State = true;
                }

            }

            if (buttonNumber - 5 >= 0)
            {
                if (buttons[buttonNumber - 5].State == true)
                {
                    buttons[buttonNumber - 5].State = !buttons[buttonNumber - 5].State;
                }
                else
                {
                    buttons[buttonNumber - 5].State = buttons[buttonNumber - 5].State = true;
                }

            }

            return View("Index", buttons);
        }
    }
}